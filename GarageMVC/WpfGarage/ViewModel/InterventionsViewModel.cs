using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GarageMVC.DataAccess.BusinessModel;
using GarageMVC.DataAccess.Services;
using WpfGarage.View;

namespace WpfGarage.ViewModel
{
    public class InterventionsViewModel: BaseViewModel
    {
        public InterventionService Serv;

        public ObservableCollection<InterventionViewModel> InterventionsVM { get; set; }

        private InterventionViewModel NewIntervention = new InterventionViewModel(new Intervention());
        public InterventionViewModel newIntervention
        {
            get { return newIntervention; }
            set { newIntervention = value; NotifyPropertyChanged(); }
        }
        public InterventionsViewModel(int id)
        {
            Serv = new InterventionService();
            InterventionsVM = new ObservableCollection<InterventionViewModel>();

        }

        private void DeleteIntervention(InterventionViewModel Item)
        {
            if (Item != null)
                Serv.Delete(Item);
        }

        private void DetailIntervention(InterventionViewModel Item)
        {
            DetailIntervention detailWindow = new DetailIntervention(Item);
            detailWindow.Show();
        }
    }
}
