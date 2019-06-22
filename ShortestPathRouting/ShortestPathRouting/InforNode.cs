using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ShortestPathRouting
{
    public partial class InforNode : Form
    {
        public InforNode()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            Setup();
        }

        private static List<byte> Data = new List<byte>();

        public void Setup()
        {
            Node node = ChangePath.GetNode;
            ChangePath.GetNode = null;

            lbNodeName.Text = node.Vertex.ToString();
            lbnumQueue.Text = node.Queue.Count.ToString();
            lbnumData.Text = node.DataNode.Count.ToString();

            if(lbnumData.Text == "0")
            {
                lbStatus.Text = "NO";
            }
            else
            {
                if(Encoding.UTF8.GetString(node.DataNode.GetRange(node.DataNode.Count - 5, 5).ToArray()) == ChangePath.TypeEnd)
                {
                    lbStatus.Text = "Done";
                    string s = Encoding.UTF8.GetString(node.DataNode.GetRange(0, 100).ToArray());
                    string parrent = "%%%%%(.*?)%%%%%";
                    var ls = Regex.Matches(s, parrent, RegexOptions.Singleline);
                    string filename = ls[0].ToString().Substring(5, ls[0].ToString().Length - 10);
                    linkDownload.Text = filename;
                    Data = node.DataNode.GetRange(ls[0].Length, node.DataNode.Count - filename.Length - 15);
                }
                else
                {
                    lbStatus.Text = "Receiving...";
                    linkDownload.Text = "Waiting...";
                }
            }
        }

        private void linkDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(lbStatus.Text == "Done")
            {
                SaveFileDialog save = new SaveFileDialog();
                string[] type = linkDownload.Text.Split('.');
                save.Filter = $"TYPE File (*.{type[type.Length - 1]})|*.{type[type.Length - 1]}";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    string filename = linkDownload.Text.Substring(0, linkDownload.Text.Length - type[type.Length - 1].Length - 1);
                    System.IO.File.WriteAllBytes(save.FileName, Data.ToArray());
                }
            }
        }
    }
}
