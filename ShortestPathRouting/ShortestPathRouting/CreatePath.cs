using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShortestPathRouting
{
    public partial class CreatePath : Form
    {
        public CreatePath()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            cbVector.DataSource = Vectors;
            cbVector.DisplayMember = "VectorName";
        }

        private int Source;

        private int Dest;

        private int Link;

        private List<Vector> Vectors = new List<Vector>()
        {
            new Vector("Vector 2D", true),
            new Vector("Vector 1D", false)
        };

        private void btnCreatePath_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txbSource.Text, out Source) && int.TryParse(txbDest.Text, out Dest) && int.TryParse(txbLink.Text, out Link))
            {
                ChangePath.path = new Path(Source, Dest, Link, Vectors.Find(v => v.VectorName == cbVector.Text).Vector_2D);
                ChangePath.isCreatePath = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Input data must be interger");
            }
        }

        private void btnDeletePath_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txbSource.Text, out Source) && int.TryParse(txbDest.Text, out Dest) && int.TryParse(txbLink.Text, out Link))
            {
                ChangePath.path = new Path(Source, Dest, Link, Vectors.Find(v => v.VectorName == cbVector.Text).Vector_2D);
                ChangePath.isDeletePath = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Input data must be interger");
            }
        }

        private void CreatePath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreatePath_Click(sender, new EventArgs());
            }
        }
    }

    public class Vector
    {
        public string VectorName { get; set; }

        public bool Vector_2D { get; set; }

        public Vector(string vectorname, bool vector_2d)
        {
            VectorName = vectorname;
            Vector_2D = vector_2d;
        }
    }
}
