using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortestPathRouting
{
    public partial class Form1 : Form
    {

        #region Key Press

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = MyColor;
            dgvNode.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNode.AllowUserToAddRows = false;
            dgvNode.DataSource = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            cbAlgorithms.DataSource = Algorithms;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.O:
                        btnOpenFile_Click(this, new EventArgs());
                        break;
                    case Keys.S:
                        btnSaveFile_Click(this, new EventArgs());
                        break;
                    case Keys.R:
                        btnRouting_Click(this, new EventArgs());
                        break;
                    case Keys.D:
                        DeleteAllData();
                        break;
                    case Keys.P:
                        CreateNewPath();
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region Memmory

        private List<string> Algorithms = new List<string>()
        {
            "Kruskal",
            "Prim",
            "Bellman-Ford",
            "Dijsktra",
        };

        private Color MyColor = Control.DefaultBackColor;

        private List<Path> Paths = new List<Path>();

        private List<Node> Nodes = new List<Node>();

        private DataTable Table = new DataTable();

        private int StepRunning = 0;

        private List<Node> SourcesTempStep = new List<Node>();

        // item = SourceTempStep
        private List<List<Node>> UpdateHistory = new List<List<Node>>();

        private List<Node> SourceListDijsktra = new List<Node>();

        #endregion

        #region Routing

        #region function Display

        //Create Nodes
        private List<Node> SetupNodes(List<Path> paths)
        {
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < CountNode(paths); i++)
            {
                nodes.Add(new Node(i));
            }
            return nodes;
        }

        //Create Source
        private List<Node> SetSource(int vertex, int distance, List<Node> nodes)
        {
            nodes.Find(n => n.Vertex == vertex).Distance = distance;
            nodes.Find(n => n.Vertex == vertex).VertexSource = vertex;

            return nodes;
        }

        private int CountNode(List<Path> paths)
        {
            //int result = 0;
            //for (int i = 0; i < paths.Count; i++)
            //{
            //    if (result < paths[i].Dest)
            //    {
            //        result = paths[i].Dest;
            //    }
            //}
            //for (int i = 0; i < paths.Count; i++)
            //{
            //    if (result < paths[i].Source)
            //    {
            //        result = paths[i].Source;
            //    }
            //}
            //return result + 1;

            return Nodes.Count;
        }

        // Display
        private string ConvertInfinity(int i)
        {
            if (i > 10000)
                return "-";
            else
                return i.ToString();
        }

        private int ConvertInt(string i)
        {
            if (i == "-")
                return 100000000;
            else
                return int.Parse(i);
        }

        private void AddItemDataGrideView(List<Node> nodes, DataTable table)
        {
            List<Node> ListNodes = nodes.OrderBy(x => x.Vertex).ToList();
            DataRow row = table.NewRow();
            if (cbAlgorithms.Text == "Dijsktra")
            {
                string s = "";
                foreach (var item in SourceListDijsktra)
                {
                    s += item.Vertex.ToString() + ",";
                }
                s = s.Remove(s.Length - 1, 1);
                row["S"] = s;
            }
            for (int i = 0; i < ListNodes.Count; i++)
            {
                row[ListNodes[i].Vertex.ToString()] = ConvertInfinity(ListNodes[i].VertexSource)
                    + "," + ConvertInfinity(ListNodes[i].Distance);
            }
            table.Rows.Add(row);
        }

        private void AddItemDataGridViewKruskal(List<Node> source, List<Path> path, DataTable table)
        {
            DataRow row = table.NewRow();
            string s = "";
            foreach (var item in source)
            {
                s += item.Vertex.ToString() + ",";
            }
            if (s.Length > 1)
                row["Source"] = s.Remove(s.Length - 1, 1);

            string p = "";
            foreach (var item in path)
            {
                p += item.Source.ToString() + "-" + item.Dest.ToString() + "=" + item.Link.ToString() + ",";
            }
            if (p.Length > 1)
                row["Path"] = p.Remove(p.Length - 1, 1);

            table.Rows.Add(row);
        }

        #endregion

        //
        // Dijsktra
        //
        #region Dijsktra

        private List<Path> SourcePathDijsktra = new List<Path>();

        private void AddSource(List<Node> temp)
        {
            foreach (var item in temp)
            {
                Node node = SourceListDijsktra.Find(n => n.Vertex == item.Vertex);
                if (node == null)
                    SourceListDijsktra.Add(item);
            }
        }

        private int Update(List<Node> SourceTemp, List<Path> Paths, out List<Node> NewSource)
        {
            int x = 0;
            StepRunning++;
            List<Node> newSource = new List<Node>();
            foreach (var source in SourceTemp)
            {
                foreach (var node in Nodes)
                {
                    if (source.Vertex != node.Vertex)
                    {
                        Path path = Paths.Find(p => (p.Source == source.Vertex && p.Dest == node.Vertex)
                                                 || (p.Dest == source.Vertex && p.Source == node.Vertex && p.Vector));
                        if (path != null)
                        {
                            if (node.Distance > source.Distance + path.Link)
                            {

                                if (node.VertexSource > 10000)
                                {
                                    DrawPath(Pens.Red, path);
                                    SourcePathDijsktra.Add(path);
                                }
                                else
                                {
                                    Path p1 = Paths.Find(p => (p.Source == node.VertexSource && p.Dest == node.Vertex)
                                                        || (p.Dest == node.VertexSource && p.Source == node.Vertex && p.Vector));
                                    DrawPath(Pens.Black, p1);
                                    SourcePathDijsktra.Remove(p1);
                                    DrawPath(Pens.Red, path);
                                    SourcePathDijsktra.Add(path);
                                }

                                node.Distance = source.Distance + path.Link;
                                node.VertexSource = source.Vertex;
                                x++;
                                if (newSource.Find(n => n.Vertex == node.Vertex) != null)
                                {
                                    newSource.Find(n => n.Vertex == node.Vertex).Distance = node.Distance;
                                    newSource.Find(n => n.Vertex == node.Vertex).VertexSource = node.VertexSource;

                                }
                                else
                                {
                                    newSource.Add(node);
                                }
                            }
                        }
                    }
                }
            }
            if (x == 0)
            {
                NewSource = SourceTemp;
            }
            else
            {
                NewSource = newSource;
                UpdateHistory.Add(newSource);//
            }
            return x;
        }

        private void SetupRouting(List<Path> paths)
        {
            Table = new DataTable();
            foreach (var item in Nodes)
            {
                if (item.Vertex != int.Parse(txbSetSource.Text))
                {
                    item.VertexSource = 100000000;
                    item.Distance = 100000000;
                }
            }
            Nodes = Nodes.OrderBy(n => n.Vertex).ToList();
            if (cbAlgorithms.Text == "Dijsktra")
            {
                Table.Columns.Add("S");
            }

            for (int i = 0; i < Nodes.Count; i++)
            {
                Table.Columns.Add(Nodes[i].Vertex.ToString(), typeof(string));
            }

            // Khoi tao
            SourcesTempStep = new List<Node>()
            {
                Nodes.Find(n => n.Distance == 0)
            };
            UpdateHistory.Add(SourcesTempStep);//
            AddSource(SourcesTempStep);

            StepRunning++;
            AddItemDataGrideView(Nodes, Table);
        }

        private void UpdateLoop(List<Path> paths)
        {
            int check = 0;
            do
            {
                check = Update(SourcesTempStep, paths, out SourcesTempStep);
                AddSource(SourcesTempStep);
                AddItemDataGrideView(Nodes, Table);
            } while (check > 0);

            Table.Rows.RemoveAt(--StepRunning);
            dgvNode.DataSource = Table;
        }

        private void Dijsktra(List<Path> paths)
        {
            StepRunning = 0;
            SetupRouting(paths);
            UpdateLoop(paths);
        }

        #endregion

        //
        // Bellman-Ford
        //
        #region Bellman-Ford

        private void BellmanFord(List<Path> paths)
        {
            StepRunning = 0;
            SetupRouting(paths);
            UpdateLoop(paths);
        }

        #endregion

        //
        // Kruskal
        //
        #region Kruskal

        private List<Node> SourceNodeKruskal = new List<Node>();
        private List<Path> SourcePathKruskal = new List<Path>();
        private static int processKruskal = 0;

        private void Kruskal(List<Path> paths)
        {
            Table = new DataTable();
            Table.Columns.Add("Source");
            Table.Columns.Add("Path");

            List<Path> pathsort = paths.OrderBy(p => p.Link).ToList();
            List<Node> sumNode = new List<Node>();

            for (int i = 0; i < pathsort.Count; i++)
            {
                if (SourceNodeKruskal.Count == Nodes.Count)
                {
                    if (sumNode.Count == 0)
                    {
                        sumNode.Add(SourceNodeKruskal.Find(s => s.Vertex == SourcePathKruskal[0].Source));
                    }
                    int dem;
                    do
                    {
                        dem = 0;
                        foreach (var item in SourcePathKruskal)
                        {
                            if (sumNode.Find(s => s.Vertex == item.Source) != null)
                            {
                                if (sumNode.Find(s => s.Vertex == item.Dest) == null)
                                {
                                    AddNodeKruskal(item, sumNode);
                                    dem++;
                                }
                            }
                            else
                            {
                                if (sumNode.Find(s => s.Vertex == item.Dest) != null)
                                {
                                    AddNodeKruskal(item, sumNode);
                                    dem++;
                                }
                            }
                        }
                    }
                    while (dem != 0);

                    if (sumNode.Count != Nodes.Count)
                    {
                        if (sumNode.Find(n => n.Vertex == pathsort[i].Source) == null || sumNode.Find(n => n.Vertex == pathsort[i].Dest) == null)
                        {
                            SourcePathKruskal.Add(pathsort[i]);
                            DrawPath(Pens.Red, pathsort[i]);
                            AddItemDataGridViewKruskal(SourceNodeKruskal, SourcePathKruskal, Table);
                        }
                    }
                    else { break; }
                }
                else if (CheckPathKruskal(pathsort[i]))
                {
                    AddSourceKruskal(pathsort[i]);
                    AddItemDataGridViewKruskal(SourceNodeKruskal, SourcePathKruskal, Table);
                }
                else
                {
                    continue;
                }
            }

            foreach (var item in SourcePathKruskal)
            {
                DrawPath(Pens.Red, item);
            }

            dgvNode.DataSource = Table;
        }

        private bool CheckPathKruskal(Path path)
        {
            int s = path.Source;
            int d = path.Dest;

            if (SourceNodeKruskal.Find(n => n.Vertex == s) != null && SourceNodeKruskal.Find(n => n.Vertex == d) != null)
                return false;
            else
                return true;
        }

        private void AddSourceKruskal(Path path)
        {
            int s = path.Source;
            int d = path.Dest;

            if (SourceNodeKruskal.Find(n => n.Vertex == s) == null)
                SourceNodeKruskal.Add(Nodes.Find(n => n.Vertex == s));
            if (SourceNodeKruskal.Find(n => n.Vertex == d) == null)
                SourceNodeKruskal.Add(Nodes.Find(n => n.Vertex == d));

            SourcePathKruskal.Add(path);
        }

        private void AddNodeKruskal(Path path, List<Node> lsNode)
        {
            int s = path.Source;
            int d = path.Dest;

            if (lsNode.Find(n => n.Vertex == s) == null)
                lsNode.Add(Nodes.Find(n => n.Vertex == s));
            if (lsNode.Find(n => n.Vertex == d) == null)
                lsNode.Add(Nodes.Find(n => n.Vertex == d));
        }

        private void DeleteDataKruskal()
        {
            SourceNodeKruskal = new List<Node>();
            SourcePathKruskal = new List<Path>();
        }

        #endregion

        //
        // Prim
        //
        #region Prim
        private void Prim(List<Path> paths)
        {
            Table = new DataTable();
            Table.Columns.Add("Source");
            Table.Columns.Add("Path");

            SourceNodeKruskal.Add(Nodes.Find(n => n.Vertex == int.Parse(txbSetSource.Text)));
            SourceNodeKruskal[0].ButtonNode.BackColor = Color.Red;
            AddItemDataGridViewKruskal(SourceNodeKruskal, SourcePathKruskal, Table);

            while (SourceNodeKruskal.Count != Nodes.Count)
            {
                List<Path> pathsort = getPathSource(SourceNodeKruskal);

                for (int i = 0; i < pathsort.Count; i++)
                {
                    if (CheckPathKruskal(pathsort[i]))
                    {
                        AddSourceKruskal(pathsort[i]);
                        AddItemDataGridViewKruskal(SourceNodeKruskal, SourcePathKruskal, Table);
                    }
                    else
                    {
                        continue;
                    }
                }

                foreach (var item in SourcePathKruskal)
                {
                    DrawPath(Pens.Red, item);
                }
            }
            dgvNode.DataSource = Table;
        }

        private List<Path> getPathSource(List<Node> nodesource)
        {
            List<Path> paths = new List<Path>();
            foreach (var item in Paths)
            {
                if (SourcePathKruskal.Find(p => p.Source == item.Source && p.Dest == item.Dest) == null && nodesource.Find(ns => ns.Vertex == item.Source || ns.Vertex == item.Dest) != null)
                {
                    paths.Add(item);
                }
            }
            return paths;
        }

        #endregion

        #region Button Display

        private static bool CheckIsRouting = false;

        private void btnRouting_Click(object sender, EventArgs e)
        {
            CheckIsRouting = true;
            switch (cbAlgorithms.Text)
            {
                case "Dijsktra":
                    btnSetSource_Click(sender, e);
                    Dijsktra(Paths);
                    break;
                case "Bellman-Ford":
                    btnSetSource_Click(sender, e);
                    Dijsktra(Paths);
                    break;
                case "Kruskal":
                    Kruskal(Paths);
                    break;
                case "Prim":
                    Prim(Paths);
                    break;
                default:
                    break;
            }

        }

        private void btnStepRun_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cbAlgorithms.Text)
                {
                    case "Kruskal":
                        processKruskal++;
                        StepRunKruskal(Paths);
                        break;
                    case "Prim":
                        StepRunPrim();
                        break;
                    default:
                        StepRunDijsktra();
                        break;
                }

            }
            catch
            {
                MessageBox.Show("You don't set source module");
            }
        }

        private void StepRunKruskal(List<Path> paths)
        {
            Table = new DataTable();
            Table.Columns.Add("Source");
            Table.Columns.Add("Path");
            DeleteDataKruskal();
            List<Path> pathsort = paths.OrderBy(p => p.Link).ToList();
            List<Node> sumNode = new List<Node>();

            for (int i = 0; i < processKruskal; i++)
            {
                if (SourceNodeKruskal.Count == Nodes.Count)
                {
                    if (sumNode.Count == 0)
                    {
                        sumNode.Add(SourceNodeKruskal.Find(s => s.Vertex == SourcePathKruskal[0].Source));
                    }
                    int dem;
                    do
                    {
                        dem = 0;
                        foreach (var item in SourcePathKruskal)
                        {
                            if (sumNode.Find(s => s.Vertex == item.Source) != null)
                            {
                                if (sumNode.Find(s => s.Vertex == item.Dest) == null)
                                {
                                    AddNodeKruskal(item, sumNode);
                                    dem++;
                                }
                            }
                            else
                            {
                                if (sumNode.Find(s => s.Vertex == item.Dest) != null)
                                {
                                    AddNodeKruskal(item, sumNode);
                                    dem++;
                                }
                            }
                        }
                    }
                    while (dem != 0);

                    if (sumNode.Count != Nodes.Count)
                    {
                        if (sumNode.Find(n => n.Vertex == pathsort[i].Source) == null || sumNode.Find(n => n.Vertex == pathsort[i].Dest) == null)
                        {
                            SourcePathKruskal.Add(pathsort[i]);
                            DrawPath(Pens.Red, pathsort[i]);
                            AddItemDataGridViewKruskal(SourceNodeKruskal, SourcePathKruskal, Table);
                        }
                    }
                    else { processKruskal--; MessageBox.Show("Routing complete"); break; }
                }
                else if (CheckPathKruskal(pathsort[i]))
                {
                    AddSourceKruskal(pathsort[i]);
                    AddItemDataGridViewKruskal(SourceNodeKruskal, SourcePathKruskal, Table);
                }
                else
                {
                    continue;
                }
            }

            foreach (var item in SourcePathKruskal)
            {
                DrawPath(Pens.Red, item);
            }
            dgvNode.DataSource = Table;
        }

        private void StepRunPrim()
        {
            if (processKruskal == 0)
            {
                Table = new DataTable();
                Table.Columns.Add("Source");
                Table.Columns.Add("Path");

                SourceNodeKruskal.Add(Nodes.Find(n => n.Vertex == int.Parse(txbSetSource.Text)));
                processKruskal++;
                SourceNodeKruskal[0].ButtonNode.BackColor = Color.Red;
                AddItemDataGridViewKruskal(SourceNodeKruskal, SourcePathKruskal, Table);
            }
            else if (SourceNodeKruskal.Count == Nodes.Count)
            {
                MessageBox.Show("Routing complete!");
            }
            else
            {
                List<Path> pathsort = getPathSource(SourceNodeKruskal);

                for (int i = 0; i < pathsort.Count; i++)
                {
                    if (CheckPathKruskal(pathsort[i]))
                    {
                        AddSourceKruskal(pathsort[i]);
                        AddItemDataGridViewKruskal(SourceNodeKruskal, SourcePathKruskal, Table);
                    }
                    else
                    {
                        continue;
                    }
                }

                foreach (var item in SourcePathKruskal)
                {
                    DrawPath(Pens.Red, item);
                }
                processKruskal++;
                dgvNode.DataSource = Table;
            }
        }

        private void StepRunDijsktra()
        {
            if (StepRunning == 0)
            {
                SetupRouting(Paths);
            }
            else
            {
                int x = Update(SourcesTempStep, Paths, out SourcesTempStep);
                if (x != 0)
                {
                    if (cbAlgorithms.Text == "Dijsktra")
                        AddSource(SourcesTempStep);

                    AddItemDataGrideView(Nodes, Table);
                }
                else
                {
                    StepRunning = StepRunning - 1;//
                    MessageBox.Show("Complete!");
                }
            }
            dgvNode.DataSource = Table;
        }

        private void btnStepBack_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cbAlgorithms.Text)
                {
                    case "Kruskal":
                        StepBackKruskal();
                        break;
                    case "Prim":
                        StepBackPrim();
                        break;
                    default:
                        StepBackDisktra();
                        break;
                }
            }
            catch
            {
                MessageBox.Show("This is function");
            }
        }

        private void StepBackKruskal()
        {
            foreach (var item in Paths)
            {
                DrawPath(Pens.Black, item);
            }
            DeleteDataKruskal();
            processKruskal = processKruskal - 1;
            StepRunKruskal(Paths);
        }

        private void StepBackPrim()
        {
            foreach (var item in Paths)
            {
                DrawPath(Pens.Black, item);
            }

            int checkstep = processKruskal - 1;
            processKruskal = 0;
            DeleteDataKruskal();
            while (checkstep > processKruskal)
            {
                StepRunPrim();
            }
            processKruskal = checkstep;
        }

        private void StepBackDisktra()
        {
            if (StepRunning - 1 == 0)
            {
                SourcesTempStep = UpdateHistory[--StepRunning];
                Table.Rows.RemoveAt(StepRunning);
            }
            if (StepRunning - 1 > 0)
            {
                // Setup Step
                StepRunning = StepRunning - 1;
                SourcesTempStep = UpdateHistory[StepRunning - 1];

                // Remove 1 step
                UpdateHistory.RemoveAt(StepRunning);
                Table.Rows.RemoveAt(StepRunning);

                //
                DataRow rows = Table.Rows[StepRunning - 1];

                if (cbAlgorithms.Text == "Dijsktra")
                {
                    SourceListDijsktra.RemoveRange(0, SourceListDijsktra.Count - 1);
                    List<string> sourceDijsktra = rows[0].ToString().Split(',').ToList();
                    //MessageBox.Show(sourceDijsktra.Count.ToString());
                    foreach (var item in sourceDijsktra)
                    {
                        Node n_sourceDijsktra = Nodes.Find(n => n.Vertex == int.Parse(item));
                        SourceListDijsktra.Add(n_sourceDijsktra);
                    }
                    for (int i = 1; i <= Nodes.Count; i++)
                    {
                        Node node = Nodes.Find(n => n.Vertex == i - 1);
                        List<string> list = rows[i].ToString().Split(',').ToList();
                        node.VertexSource = ConvertInt(list[0]);
                        node.Distance = ConvertInt(list[1]);
                    }
                }
                else //Bellman-ford
                {
                    for (int i = 0; i < Nodes.Count; i++)
                    {
                        Node node = Nodes.Find(n => n.Vertex == i);
                        List<string> list = rows[i].ToString().Split(',').ToList();
                        node.VertexSource = ConvertInt(list[0]);
                        node.Distance = ConvertInt(list[1]);
                    }
                }
            }

            // Paint Path
            foreach (var item in Paths)
            {
                DrawPath(Pens.Black, item);
            }
            foreach (var item in Nodes)
            {
                if (item.Distance > 0 && item.Distance < 1000000)
                {
                    Path p1 = Paths.Find(p => (p.Source == item.VertexSource && p.Dest == item.Vertex)
                                        || (p.Dest == item.VertexSource && p.Source == item.Vertex && p.Vector));

                    DrawPath(Pens.Red, p1);
                }
            }
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want delete all graph?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            CheckIsRouting = false;
            SourcesTempStep = new List<Node>();
            SourceListDijsktra = new List<Node>();
            UpdateHistory = new List<List<Node>>();
            DeleteDataKruskal();
            processKruskal = 0;
            NumberOfNodes = 0;

            SourcePathDijsktra = new List<Path>();
            SourcePathKruskal = new List<Path>();

            if (dialog == DialogResult.Yes)
            {
                DeleteAllData();
            }
            else if (dialog == DialogResult.No)
            {
                foreach (var item in Nodes)
                {
                    item.VertexSource = 100000000;
                    item.Distance = 100000000;
                    item.ButtonNode.BackColor = MyColor;
                }
                foreach (var item in Paths)
                {
                    DrawPath(Pens.Black, item);
                }
                StepRunning = 0;
                Table = new DataTable();
                dgvNode.DataSource = Table;
            }
            else
            {

            }
        }

        private void DeleteAllData()
        {
            foreach (var nodeDelete in Nodes)
            {
                List<Path> pathDeletes = new List<Path>();
                if (nodeDelete != null)
                {
                    foreach (var item in Paths)
                    {
                        if (item.Source == nodeDelete.Vertex || item.Dest == nodeDelete.Vertex)
                        {
                            pathDeletes.Add(item);
                            DrawPath(new Pen(MyColor), item);
                            Control[] checklb = this.Controls.Find($"Node{item.Source}_Node{item.Dest}_{item.Link}_{item.Vector}", true);
                            this.Controls.Remove(checklb[0]);
                            checklb[0].Dispose();
                        }
                    }

                    foreach (var item in pathDeletes)
                    {
                        Paths.Remove(item);

                    }
                    //Nodes.Remove(nodeDelete);
                    Control[] btnDel = this.Controls.Find(nodeDelete.Vertex.ToString(), true);
                    this.Controls.Remove(btnDel[0]);
                    btnDel[0].Dispose();
                }
            }
            Nodes.RemoveRange(0, Nodes.Count);
            Table = new DataTable();
            StepRunning = 0;

            dgvNode.DataSource = Table;
        }

        private void btnSetSource_Click(object sender, EventArgs e)
        {
            int x;

            if (int.TryParse(txbSetSource.Text, out x))
            {
                Node node = Nodes.Find(n => n.Vertex == x);
                if (node != null)
                {
                    Node source = Nodes.Find(n => n.VertexSource == 0 && n.Distance == 0);
                    if (source != null)
                    {
                        source.VertexSource = 100000000;
                        source.Distance = 100000000;
                        source.ButtonNode.BackColor = MyColor;
                    }

                    node.VertexSource = 0;
                    node.Distance = 0;
                    node.ButtonNode.BackColor = Color.Red;
                }
            }
        }

        private void btnSourceDest_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckIsRouting)
                    btnRouting_Click(this, new EventArgs());

                switch (cbAlgorithms.Text)
                {
                    case "Kruskal":
                        DetectNodetoNode(SourcePathKruskal);
                        break;
                    case "Prim":
                        DetectNodetoNode(SourcePathKruskal);
                        break;
                    case "Dijsktra":
                        DetectNodetoNode(SourcePathDijsktra);
                        break;
                    case "Bellman-Ford":
                        DetectNodetoNode(SourcePathDijsktra);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Reset data -> Click Routing -> Choose node to detect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private List<Path> DetectPathNodetoNodes = new List<Path>();

        private bool AddNodeRelation(Node relationNode, List<RelationNode> tree)
        {
            RelationNode reNode = tree.Find(t => t.NameNode.Vertex == relationNode.Vertex);
            if (reNode == null)
                return true;
            else
                return false;
        }

        private void DetectNodetoNode(List<Path> paths)
        {
            Node nodeSource = Nodes.Find(n => n.Vertex == int.Parse(txbSetSource.Text));
            Node nodeDest = Nodes.Find(n => n.Vertex == int.Parse(txbDest.Text));
            List<Path> SourcePathDetect = paths;

            List<RelationNode> TreeNode = new List<RelationNode>();
            int rank = 0;

            TreeNode.Add(new RelationNode(nodeSource, rank, nodeSource));

            do
            {
                rank = rank + 1;
                List<Path> path = new List<Path>();
                List<Node> source = new List<Node>();

                foreach (var item in TreeNode)
                {
                    source.Add(item.NameNode);
                }
                foreach (var item in source)
                {
                    path.AddRange(SourcePathDetect.Where(p => p.Source == item.Vertex || p.Dest == item.Vertex));
                }
                foreach (var item in path)
                {
                    if (source.Find(n => n.Vertex == item.Source) == null)
                    {
                        Node node = Nodes.Find(n => n.Vertex == item.Source);
                        if (AddNodeRelation(node, TreeNode))
                            TreeNode.Add(new RelationNode(node, rank, source.Find(n => n.Vertex == item.Dest)));
                    }
                    else
                    {
                        Node node = Nodes.Find(n => n.Vertex == item.Dest);
                        if (AddNodeRelation(node, TreeNode))
                            TreeNode.Add(new RelationNode(node, rank, source.Find(n => n.Vertex == item.Source)));
                    }
                }

            } while (TreeNode.Count != Nodes.Count);

            //Detect
            RelationNode relationNodeDest = TreeNode.Find(tn => tn.NameNode.Vertex == nodeDest.Vertex);
            do
            {
                RelationNode ParentNodeDetect = TreeNode.Find(tn => tn.NameNode.Vertex == relationNodeDest.NodeParent.Vertex);

                Path path = SourcePathDetect.Find(p => (p.Source == relationNodeDest.NameNode.Vertex && p.Dest == ParentNodeDetect.NameNode.Vertex)
                                                    || (p.Dest == relationNodeDest.NameNode.Vertex && p.Source == ParentNodeDetect.NameNode.Vertex));

                DrawPath(Pens.Blue, path);
                DetectPathNodetoNodes.Add(path);
                relationNodeDest = ParentNodeDetect;
            } while (relationNodeDest.NameNode.Vertex != nodeSource.Vertex);
        }

        #endregion

        #endregion

        #region Paint Node

        // Paint 2D
        private bool isCreateNode = false;

        private int NumberOfNodes = 0;

        private bool dragging = false;

        private int startX = 0;

        private int startY = 0;

        private int sizeXY = 30;

        private void PaintNode(string name, int x, int y)
        {
            // Setup button
            Button button = new Button();
            button.Name = name;
            button.Text = name;
            button.Location = new Point(x, y);
            button.Size = new Size(sizeXY, sizeXY);

            // Add List Nodes
            Nodes.Add(new Node(int.Parse(name), button));

            // Event
            this.Controls.Add(button);
            button.MouseDown += Button_MouseDown;
            button.MouseMove += Button_MouseMove;
            button.MouseUp += Button_MouseUp;
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Node node = Nodes.Find(n => n.ButtonNode.Name == button.Name);
            //MessageBox.Show(node.Queue.Count.ToString() + "\n" + node.DataNode.Count.ToString());
            ChangePath.GetNode = node;
            InforNode infor = new InforNode();
            infor.ShowDialog();
            //CreateThreadReceive(node);
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Button button = sender as Button;
                startX = e.X;
                startY = e.Y;
                dragging = true;
            }
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (dragging)
            {
                Node n = Nodes.Find(x => x.ButtonNode == button);
                List<Path> paths = Paths.Where(p => p.Source == n.Vertex || p.Dest == n.Vertex).ToList();
                foreach (var item in paths)
                {
                    DrawPath(new Pen(MyColor), item);
                }

                int l = button.Left + e.X - startX;
                int t = button.Top + e.Y - startY;
                int w = button.Width;
                int h = button.Height;
                t = (t < 0) ? 0 : ((t + h > button.Parent.ClientRectangle.Height) ?
                    button.Parent.ClientRectangle.Height - h : t);
                l = (l < 0) ? 0 : ((l + w > button.Parent.ClientRectangle.Width) ?
                    button.Parent.ClientRectangle.Width - w : l);
                button.Left = l;
                button.Top = t;

                //
                foreach (var item in paths)
                {
                    Node n_s = Nodes.Find(x => x.Vertex == item.Source);
                    Node n_d = Nodes.Find(x => x.Vertex == item.Dest);

                    if (n_s.VertexSource == n_d.Vertex || n_s.Vertex == n_d.VertexSource)
                    {
                        DrawPath(Pens.Red, item);
                    }
                    else
                    {
                        DrawPath(Pens.Black, item);
                    }

                    if (cbAlgorithms.Text == "Kruskal" || cbAlgorithms.Text == "Prim")
                    {
                        if (SourcePathKruskal.Find(p => p.Source == item.Source && p.Dest == item.Dest) != null)
                            DrawPath(Pens.Red, item);
                        else
                            DrawPath(Pens.Black, item);
                    }

                    if (DetectPathNodetoNodes.Find(p => p.Source == item.Source && p.Dest == item.Dest) != null)
                        DrawPath(Pens.Blue, item);
                }
            }
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void btnCreateNode_Click(object sender, EventArgs e)
        {
            if (isCreateNode)
            {
                isCreateNode = false;
                btnCreateNode.Text = "Create node";
            }
            else
            {
                isCreateNode = true;
                btnCreateNode.Text = "Node " + NumberOfNodes.ToString();
            }
        }

        private void btnDeleteNode_Click(object sender, EventArgs e)
        {
            Node nodeDelete = Nodes.Find(n => n.Vertex == int.Parse(txbSetSource.Text));
            List<Path> pathDeletes = new List<Path>();
            if (nodeDelete != null)
            {
                foreach (var item in Paths)
                {
                    if (item.Source == nodeDelete.Vertex || item.Dest == nodeDelete.Vertex)
                    {
                        pathDeletes.Add(item);
                        DrawPath(new Pen(MyColor), item);
                        Control[] checklb = this.Controls.Find($"Node{item.Source}_Node{item.Dest}_{item.Link}_{item.Vector}", true);
                        this.Controls.Remove(checklb[0]);
                        checklb[0].Dispose();
                    }
                }

                foreach (var item in pathDeletes)
                {
                    Paths.Remove(item);

                }
                Nodes.Remove(nodeDelete);
                Control[] btnDel = this.Controls.Find(nodeDelete.Vertex.ToString(), true);
                this.Controls.Remove(btnDel[0]);
                btnDel[0].Dispose();
            }
        }

        private void DrawPath(Pen pen, Path path)
        {
            Node n1 = Nodes.Find(n => n.Vertex == path.Source);
            Node n2 = Nodes.Find(n => n.Vertex == path.Dest);
            if (n1 != null && n2 != null)
            {
                // DrawLine
                Graphics g = CreateGraphics();
                float x1 = n1.ButtonNode.Location.X + sizeXY / 2;
                float y1 = n1.ButtonNode.Location.Y + sizeXY / 2;
                float x2 = n2.ButtonNode.Location.X + sizeXY / 2;
                float y2 = n2.ButtonNode.Location.Y + sizeXY / 2;
                g.DrawLine(pen, x1, y1, x2, y2);

                if (!path.Vector)
                {
                    //float x_B = (x1 + 7 * x2) / 8;
                    //float y_B = (y1 + 7 * y2) / 8;

                    //float x_A = (x2 + 3 * x_B) / 4;
                    //float y_A = (y2 + 3 * y_B) / 4;
                    float x_A = (3 * x1 + 29 * x2) / 32;
                    float y_A = (3 * y1 + 29 * y2) / 32;

                    for (float i = 0; i <= sizeXY; i = i + 2)
                    {
                        float x_C = (n1.ButtonNode.Location.X + i + 3 * x_A) / 4;
                        float y_C = (n1.ButtonNode.Location.Y + sizeXY - i + 3 * y_A) / 4;
                        g.DrawLine(pen, x_C, y_C, x_A, y_A);

                        float x_D = (n1.ButtonNode.Location.X + i + 3 * x_A) / 4;
                        float y_D = (n1.ButtonNode.Location.Y + i + 3 * y_A) / 4;
                        g.DrawLine(pen, x_D, y_D, x_A, y_A);
                    }


                }

                // Distance
                Label label = new Label();
                label.Name = $"Node{n1.Vertex}_Node{n2.Vertex}_{path.Link}_{path.Vector}";
                label.Text = path.Link.ToString();
                label.Size = new Size(25, 13);

                label.Location = new Point((int)((x1 + x2) / 2), (int)((y1 + y2) / 2));
                Control[] checklb = this.Controls.Find(label.Name, true);
                if (checklb.Length == 0)
                {
                    this.Controls.Add(label);
                }
                else
                {
                    checklb[0].Location = new Point((int)((x1 + x2) / 2), (int)((y1 + y2) / 2));
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (isCreateNode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    btnCreateNode.Text = "Node " + (NumberOfNodes + 1).ToString();
                    PaintNode(NumberOfNodes.ToString(), e.X, e.Y);
                    NumberOfNodes++;
                }
                else
                {
                    CreateNewPath();
                }
            }
        }

        private void CreateNewPath()
        {
            CreatePath createPath = new CreatePath();
            createPath.ShowDialog();

            if (ChangePath.isCreatePath)
            {
                ChangePath.isCreatePath = false;
                Node n1 = Nodes.Find(n => n.Vertex == ChangePath.path.Source);
                Node n2 = Nodes.Find(n => n.Vertex == ChangePath.path.Dest);

                if (n1 != null && n2 != null)
                {
                    Path pathCreate = Paths.Find(p => (p.Source == ChangePath.path.Source && p.Dest == ChangePath.path.Dest)
                                               || (p.Source == ChangePath.path.Dest && p.Dest == ChangePath.path.Source));

                    if (pathCreate != null) // Edit
                    {
                        DrawPath(new Pen(MyColor), pathCreate);
                        Paths.Remove(pathCreate);
                        Control[] checklbCreate = this.Controls.Find($"Node{pathCreate.Source}_Node{pathCreate.Dest}_{pathCreate.Link}_{pathCreate.Vector}", true);
                        this.Controls.Remove(checklbCreate[0]);
                        checklbCreate[0].Dispose();
                    }

                    Paths.Add(ChangePath.path);
                    DrawPath(Pens.Black, ChangePath.path);
                }

            }

            if (ChangePath.isDeletePath)
            {
                ChangePath.isDeletePath = false;
                Path pathDelete = Paths.Find(p => (p.Source == ChangePath.path.Source && p.Dest == ChangePath.path.Dest && p.Link == ChangePath.path.Link)
                                               || (p.Source == ChangePath.path.Dest && p.Dest == ChangePath.path.Source && p.Link == ChangePath.path.Link));

                if (pathDelete != null)
                {
                    DrawPath(new Pen(MyColor), pathDelete);
                    Paths.Remove(pathDelete);
                    Control[] checklb = this.Controls.Find($"Node{pathDelete.Source}_Node{pathDelete.Dest}_{pathDelete.Link}_{pathDelete.Vector}", true);
                    this.Controls.Remove(checklb[0]);
                    checklb[0].Dispose();
                }
            }

        }

        #endregion

        #region File

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFile();
                CreateThreadReceive();

            }
            catch
            {
                MessageBox.Show("File error");
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                //SaveFileDialog save = new SaveFileDialog();
                //save.Filter = $"Text File (*.txt)|*.txt";
                //if (save.ShowDialog() == DialogResult.OK)
                //{
                //    string s_path = "";
                //    for (int i = 0; i < Paths.Count; i++)
                //    {
                //        string vec = Paths[i].Vector ? "1" : "0";
                //        if (i == Paths.Count - 1)
                //        {
                //            s_path += $"{Paths[i].Source},{Paths[i].Dest},{Paths[i].Link},{vec}";
                //        }
                //        else
                //        {
                //            s_path += $"{Paths[i].Source},{Paths[i].Dest},{Paths[i].Link},{vec}" + "\r\n";
                //        }
                //    }

                //    File.WriteAllBytes(save.FileName, Encoding.UTF8.GetBytes(s_path));
                //}
                SaveFile();
            }
            catch
            {
                MessageBox.Show("Can not save file");
            }

        }

        private void SaveFile()
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = $"Text File (*.txt)|*.txt";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    string s_path = "";
                    for (int i = 0; i < Paths.Count; i++)
                    {
                        string vec = Paths[i].Vector ? "1" : "0";
                        s_path += $"P{Paths[i].Source},{Paths[i].Dest},{Paths[i].Link},{vec}P" + "\r\n";

                    }

                    for (int i = 0; i < Nodes.Count; i++)
                    {

                        s_path += $"N{Nodes[i].Vertex},{Nodes[i].ButtonNode.Location.X},{Nodes[i].ButtonNode.Location.Y}N" + "\r\n";

                    }

                    File.WriteAllBytes(save.FileName, Encoding.UTF8.GetBytes(s_path));
                }
            }
            catch
            {
                MessageBox.Show("Can not save file");
            }
        }

        private void OpenFile()
        {
            DeleteAllData();

            OpenFileDialog open = new OpenFileDialog();
            List<string> s_node = new List<string>();
            if (open.ShowDialog() == DialogResult.OK)
            {
                List<byte> Data = File.ReadAllBytes(open.FileName).ToList();
                string s_File = Encoding.UTF8.GetString(Data.ToArray());

                string patternPath = @"P(.*?)P";
                var s_listPath = Regex.Matches(s_File, patternPath, RegexOptions.Singleline);

                string patternNode = @"N(.*?)N";
                var s_listNode = Regex.Matches(s_File, patternNode, RegexOptions.Singleline);

                foreach (var node in s_listNode)
                {
                    string item = node.ToString();
                    string nodeItem = item.Substring(1, item.Length - 2);
                    string[] arrayItem = nodeItem.Split(',');

                    PaintNode(arrayItem[0], int.Parse(arrayItem[1]), int.Parse(arrayItem[2]));
                    //Nodes.Add(new Node(int.Parse(arrayItem[0])));
                }

                foreach (var path in s_listPath)
                {
                    string item = path.ToString();
                    string nodeItem = item.Substring(1, item.Length - 2);
                    string[] arrayItem = nodeItem.Split(',');

                    Paths.Add(new Path(int.Parse(arrayItem[0]), int.Parse(arrayItem[1]), int.Parse(arrayItem[2]), int.Parse(arrayItem[3]) == 0 ? false : true));
                }

                foreach (var item in Paths)
                {
                    DrawPath(Pens.Black, item);
                }

                NumberOfNodes = Nodes.Count;
            }
        }

        #endregion

        #region MultiThreading Send Data

        private List<byte> DataFile = new List<byte>();

        private string TypeFile = ChangePath.TypeSpace;

        private string TypeNode = ChangePath.TypeEnd;

        private int DelayTrans = 1;

        private void CreateThreadReceive()
        {
            new Thread(
                () =>
                {
                    while (true)
                    {
                        foreach (var node in Nodes)
                        {
                            if (node.Queue.Count > 0)
                            {
                                PacketSend packet = node.Queue[0];

                                if (packet.Tree.Length >= 1)
                                {
                                    int dest = int.Parse(node.Queue[0].Tree[0].ToString());
                                    Node NodeReceive = Nodes.Find(n => n.Vertex == dest);
                                    Path p1 = Paths.Find(n => (n.Source == node.Vertex && n.Dest == dest) || (n.Source == dest && n.Dest == node.Vertex));
                                    packet.CountSegment += 1;

                                    if (packet.CountSegment >= p1.Link)
                                    {
                                        DrawPath(packet.ColorLine, node, NodeReceive, packet.CountSegment);
                                        packet.Tree = packet.Tree.Substring(1);
                                        packet.CountSegment = 0;
                                        NodeReceive.Queue.Add(packet);
                                        node.Queue.RemoveAt(0);
                                        Thread.Sleep(DelayTrans);
                                        DrawPath(Pens.Red, node, NodeReceive, packet.CountSegment);
                                    }
                                    else
                                    {
                                        DrawPath(packet.ColorLine, node, NodeReceive, packet.CountSegment);
                                    }
                                }
                                else
                                {
                                    node.DataNode.AddRange(node.Queue[0].Data);
                                    node.Queue.RemoveAt(0);
                                }
                            }
                        }

                        Thread.Sleep(DelayTrans);
                    }
                })
            { IsBackground = true }.Start();

        }

        private void DrawPath(Pen pen, Node source, Node dest, int per)
        {
            Path path = Paths.Find(p => (p.Source == source.Vertex && p.Dest == dest.Vertex) || (p.Source == dest.Vertex && p.Dest == source.Vertex));


            // DrawLine
            Graphics g = CreateGraphics();
            float x1 = source.ButtonNode.Location.X + sizeXY / 2;
            float y1 = source.ButtonNode.Location.Y + sizeXY / 2;
            float x2 = dest.ButtonNode.Location.X + sizeXY / 2;
            float y2 = dest.ButtonNode.Location.Y + sizeXY / 2;
            float x3 = (x2 * per / path.Link) + (x1 * (path.Link - per) / path.Link);
            float y3 = (y2 * per / path.Link) + (y1 * (path.Link - per) / path.Link);
            g.DrawLine(pen, x1, y1, x3, y3);
            g.DrawLine(Pens.Red, x3, y3, x2, y2);


            // Distance
            Label label = new Label();
            label.Name = $"Node{path.Source}_Node{path.Dest}_{path.Link}_{path.Vector}";
            label.Text = path.Link.ToString();
            label.Size = new Size(25, 13);

            label.Location = new Point((int)((x1 + x2) / 2), (int)((y1 + y2) / 2));
            Control[] checklb = this.Controls.Find(label.Name, true);
            if (checklb.Length == 0)
            {
                this.Controls.Add(label);
            }
            else
            {
                checklb[0].Location = new Point((int)((x1 + x2) / 2), (int)((y1 + y2) / 2));
            }

        }

        private void btnFileSend_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ofd = new OpenFileDialog();
            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                txbFile.Text = Ofd.SafeFileName;

                DataFile.AddRange(Encoding.UTF8.GetBytes(TypeFile));
                DataFile.AddRange(Encoding.UTF8.GetBytes(txbFile.Text));
                DataFile.AddRange(Encoding.UTF8.GetBytes(TypeFile));

                DataFile.AddRange(File.ReadAllBytes(Ofd.FileName));
                DataFile.AddRange(Encoding.UTF8.GetBytes(TypeNode));
            }
        }

        // Size Packet 10 KB = 10 * 1024
        private int SizePacket = 10 * 1024;

        private void btnSendData_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(btnColor.BackColor);

            int numPacket = DataFile.Count / 10240;
            int endPacket = DataFile.Count % 10240;

            Node n1 = Nodes.Find(n => n.Vertex == int.Parse(txbSetSource.Text));
            Node n2 = Nodes.Find(n => n.Vertex == int.Parse(txbDest.Text));

            string tree = "";

            switch (cbAlgorithms.Text)
            {
                case "Kruskal":
                    tree = DetectTree(SourcePathKruskal, n1, n2);
                    break;
                case "Prim":
                    tree = DetectTree(SourcePathKruskal, n1, n2);
                    break;
                case "Dijsktra":
                    tree = DetectTree(SourcePathDijsktra, n1, n2);
                    break;
                case "Bellman-Ford":
                    tree = DetectTree(SourcePathDijsktra, n1, n2);
                    break;
                default:
                    break;
            }

            List<PacketSend> packetSends = new List<PacketSend>();
            tree = tree.Substring(1);

            for (int i = 0; i < numPacket; i++)
            {
                if (i == numPacket - 1)
                {
                    packetSends.Add(new PacketSend(tree, DataFile.GetRange(i * 10240, DataFile.Count - i * 10240), pen));
                }
                else
                {
                    packetSends.Add(new PacketSend(tree, DataFile.GetRange(i * 10240, 10240), pen));
                }
            }

            n1.Queue.AddRange(packetSends);
            DataFile = new List<byte>();
        }

        private string DetectTree(List<Path> paths, Node nodeSource, Node nodeDest)
        {
            string tree = nodeSource.Vertex.ToString();
            List<Path> DetectPathPacket = new List<Path>();
            List<Path> SourcePathDetect = paths;

            List<RelationNode> TreeNode = new List<RelationNode>();
            int rank = 0;

            TreeNode.Add(new RelationNode(nodeSource, rank, nodeSource));

            do
            {
                rank = rank + 1;
                List<Path> path = new List<Path>();
                List<Node> source = new List<Node>();

                foreach (var item in TreeNode)
                {
                    source.Add(item.NameNode);
                }
                foreach (var item in source)
                {
                    path.AddRange(SourcePathDetect.Where(p => p.Source == item.Vertex || p.Dest == item.Vertex));
                }
                foreach (var item in path)
                {
                    if (source.Find(n => n.Vertex == item.Source) == null)
                    {
                        Node node = Nodes.Find(n => n.Vertex == item.Source);
                        if (AddNodeRelation(node, TreeNode))
                            TreeNode.Add(new RelationNode(node, rank, source.Find(n => n.Vertex == item.Dest)));
                    }
                    else
                    {
                        Node node = Nodes.Find(n => n.Vertex == item.Dest);
                        if (AddNodeRelation(node, TreeNode))
                            TreeNode.Add(new RelationNode(node, rank, source.Find(n => n.Vertex == item.Source)));
                    }
                }

            } while (TreeNode.Count != Nodes.Count);

            //Detect
            RelationNode relationNodeDest = TreeNode.Find(tn => tn.NameNode.Vertex == nodeDest.Vertex);
            do
            {
                RelationNode ParentNodeDetect = TreeNode.Find(tn => tn.NameNode.Vertex == relationNodeDest.NodeParent.Vertex);

                Path path = SourcePathDetect.Find(p => (p.Source == relationNodeDest.NameNode.Vertex && p.Dest == ParentNodeDetect.NameNode.Vertex)
                                                    || (p.Dest == relationNodeDest.NameNode.Vertex && p.Source == ParentNodeDetect.NameNode.Vertex));

                DetectPathPacket.Add(path);
                relationNodeDest = ParentNodeDetect;
            } while (relationNodeDest.NameNode.Vertex != nodeSource.Vertex);

            for (int i = DetectPathPacket.Count - 1; i >= 0; i--)
            {
                if (tree[tree.Length - 1].ToString() == DetectPathPacket[i].Source.ToString())
                    tree += DetectPathPacket[i].Dest.ToString();
                else
                    tree += DetectPathPacket[i].Source.ToString();
            }

            return tree;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();

            if(color.ShowDialog() == DialogResult.OK)
            {
                string codeColor = color.Color.Name;
                btnColor.BackColor = Color.FromName(codeColor);
            }
        }

        private void btnSetupConnect_Click(object sender, EventArgs e)
        {
            CreateThreadReceive();
        }

        #endregion
    }
}
