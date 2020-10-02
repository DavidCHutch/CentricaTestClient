using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CentricaTestClient.WPF.Views
{
    /// <summary>
    /// Interaction logic for DistrictsView.xaml
    /// </summary>
    public partial class DistrictsView : UserControl
    {
		//TODO REPLACE THIS VIEW WITH ACTUAL DISTRICT DATA
        public DistrictsView()
		{
			InitializeComponent();
			List<User> userItems = new List<User>();
			userItems.Add(new User() { Name = "John Doe", Age = 42 });
			userItems.Add(new User() { Name = "Jane Doe", Age = 39 });
			userItems.Add(new User() { Name = "Sammy Doe", Age = 13 });
            DistrictListViewDataBinding.ItemsSource = userItems;
        }
		private void ListViewItem_DoubleClick(object sender, MouseButtonEventArgs e)
		{
			var obj = (DependencyObject)e.OriginalSource;

			while (obj != null && obj != DistrictListViewDataBinding)
			{
				if (obj.GetType() == typeof(ListViewItem))
				{
					// Do something here
					MessageBox.Show("A ListViewItem was double clicked!");

					break;
				}
				obj = VisualTreeHelper.GetParent(obj);
			}
		}

		public class User
		{
			public string Name { get; set; }

			public int Age { get; set; }

			public override string ToString()
			{
				return this.Name + ", " + this.Age + " years old";
			}
		}
	}
}
