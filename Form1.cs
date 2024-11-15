using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;

namespace Assignment2
{
    
    public partial class Form1 : Form
    {
        private Value defaultValue = new Value { id = "Default Value", data = "0" };
        private BindingList<Value> DataList;
        public Form1()
        {
            InitializeComponent();
            chart1.Titles.Add("Pie Chart");
            DataList = new BindingList<Value>
            {
                defaultValue
            };
            for (int i = 0; i < DataList.Count; i++)
            {
                chart1.Series["Series1"].Points.AddXY(DataList[i].id, DataList[i].data);
            }
        }

        private void add_value(object sender, EventArgs e)
        {
            DataList.Remove(defaultValue);
            string input = textBox1.Text;
            int count = DataList.Count() + 1;
            Value newdata = new Value { id = "Value " + count.ToString(), data = input};
            DataList.Add(newdata);
            textBox1.Text = "";

            update();
        }
        private void remove_all_value(object sender, EventArgs e)
        {
            DataList.Clear();
            DataList.Add(defaultValue);
            update();
        }
        private void update()
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            for (int i = 0; i < DataList.Count; i++)
            {
                chart1.Series["Series1"].Points.AddXY(DataList[i].id, DataList[i].data);
            }
        }
    }
}
