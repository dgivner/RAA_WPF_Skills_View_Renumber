using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.DB;


namespace RAA_WPF_Skills_View_Renumber
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class MyForm : Window
    {
        public List<Element> elemList;

        public MyForm(Document doc, List<Reference> refList)
        {
            InitializeComponent();

            for (int i = 1; i <= 20; i++)
            {
                cmbNumber.Items.Add(i.ToString());
            }
            if (refList != null)
            {
                lbxElements.Items.Clear();
                elemList = new List<Element>();

                foreach (Reference curRef in refList)
                {
                    Element curElem = doc.GetElement(curRef);
                    if (curElem is Viewport)
                    {
                        //Dont need to cast for view name, can use line 54 only to get viewport name
                        elemList.Add(curElem);
                        //Viewport curVP = curElem as Viewport;
                        //View curView = doc.GetElement(curVP.ViewId) as View;
                        //lbxElements.Items.Add(curView.Name + " (" + curView.Id.ToString() + ")");

                        //this only gets the ID number which isnt really helpful to the user
                        //lbxElements.Items.Add(curElem.Id.ToString());
                        //lbxElements.Items.Add(curElem.get_Parameter(BuiltInParameter.VIEWPORT_VIEW_NAME));
                        Parameter viewName = curElem.get_Parameter(BuiltInParameter.VIEW_NAME);
                        Parameter viewDetailNum = curElem.get_Parameter(BuiltInParameter.VIEWPORT_DETAIL_NUMBER);
                        //lbxElements.Items.Add("(" + viewDetailNum.AsString() + ") " + viewName.AsString());
                        lbxElements.Items.Add(viewDetailNum.AsString() + ": " + viewName.AsString() + " (" + curElem.Id.ToString() + ")");



                    }
                }
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        internal int GetStartNumber()
        {
            string selectedNumber = cmbNumber.SelectedItem.ToString();
            int returnValue = Convert.ToInt32(selectedNumber);
            return returnValue;
        }

        internal List<Element> GetSelectedViews()
        {
            if (elemList != null)
                return elemList;
            else
                return null;
        }
    }
}
