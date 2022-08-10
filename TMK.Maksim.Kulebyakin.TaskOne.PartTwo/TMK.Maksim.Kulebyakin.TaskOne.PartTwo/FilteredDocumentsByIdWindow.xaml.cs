using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using TMK.Maksim.Kulebyakin.TaskOne.PartTwo.ViewModel;

namespace TMK.Maksim.Kulebyakin.TaskOne.PartTwo
{
    /// <summary>
    /// Interaction logic for FilteredDocumentsById.xaml
    /// </summary>
    public partial class FilteredDocumentsByIdWindow : Window
    {
        private DataBaseHandler _dataBase;
        private CollectionViewSource _vData;
        private DocumentsVM _document;
        private int _target;

        public FilteredDocumentsByIdWindow(int target)
        {
            InitializeComponent();
            _vData = new CollectionViewSource();
            _dataBase = new DataBaseHandler();
            _target = target;
            Loaded += GetDocuments;
            
        }

        private async void GetDocuments(object sender, RoutedEventArgs e)
        {
            _document = new DocumentsVM();

            var documents = await _dataBase.GetFilteredDocumentsByFirmId(_target);

            _document.Documents = new ObservableCollection<DisplayedDocument>(documents);

            _vData.Source = _document.Documents;

            DocumentsGrid.ItemsSource = _vData.View;

            DataContext = _document;
        }
    }
}
