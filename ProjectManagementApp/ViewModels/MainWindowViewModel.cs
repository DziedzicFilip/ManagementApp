using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ProjectManagementApp.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using ProjectManagementApp.Views;
using GalaSoft.MvvmLight.Messaging;

namespace ProjectManagementApp.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion
        public MainWindowViewModel()
        {
            Messenger.Default.Register<string>(this, open);
        }

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
           
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Projekty",
                    new BaseCommand(() =>  this.ShowWorkspace<WszystkieProjektyViewModel>())),

                new CommandViewModel(
                    "Nowy Projekt",
                    new BaseCommand(() => this.CreateView(new NowyProjektViewModel() ))),
                 
                new CommandViewModel(
                    "Ryzyka",
                    new BaseCommand(() =>  this.ShowWorkspace<RyzykaProjektuViewModel>())),

              
                      new CommandViewModel(
                    "Stawka",
                    new BaseCommand(() => this.CreateView(new KalkulatorStawkiViewModel() ))),

                      new CommandViewModel(
                    "Podsumowanie Czasu Projektu",
                    new BaseCommand(() => this.CreateView(new PodsumowanieCzasuProjektuViewModel() ))),

                      new CommandViewModel(
                    "Budzet Projektu",
                    new BaseCommand(() => this.CreateView(new BudzetProjektuViewModel ()))),

                      new CommandViewModel(
                    "Dodaj Budzet",
                    new BaseCommand(() => this.CreateView(new DodajBudzetProjektuViewModel ()))),
                        new CommandViewModel(
                    "Dodaj Ryzko",
                    new BaseCommand(() => this.CreateView(new DodajRyzkoViewModel ()))),
                         new CommandViewModel(
                    "Dodaj Notatke",
                    new BaseCommand(() => this.CreateView(new DodajNotatakiProjektViewModel()))),
                          new CommandViewModel(
                    "Dodaj Plik",
                    new BaseCommand(() => this.CreateView(new DodajPlikProjektuViewModel()))),
                              new CommandViewModel(
                    "Dodaj Zadanie",
                    new BaseCommand(() => this.CreateView(new DodajZadaniaProjektuViewModel()))),
             


                //new CommandViewModel(
                //    "Historia Projektu ",
                //    new BaseCommand(() => this.CreateView(new WyswietlHistorieProjektuViewModel() ))),

              

                //new CommandViewModel(
                //    "Event informacje",
                //    new BaseCommand(() => this.CreateView(new InformacjeEventViewModel() ))),

                 

                    //new CommandViewModel(
                    //"Tagi",
                    //new BaseCommand(() =>  this.ShowWorkspace<WszystkieTagiViewModel>())),

                 
                   //new CommandViewModel(
                   // "Nowy Tag",
                   // new BaseCommand(() => this.CreateView(new NowyTagViewModel () ))),

                    //new CommandViewModel(
                    //"Kalendarz",
                    //new BaseCommand(() => this.CreateView(new KalendarzViewModel () ))),

                    
                    new CommandViewModel(
                    "Czas Pracy",
                    new BaseCommand(() =>  this.ShowWorkspace<CzasPracyWindowViewModel>())),
                    //  new CommandViewModel(
                    //"Historie Pracy ",
                    //new BaseCommand(() =>  this.ShowWorkspace<HistoriaWindowViewModel>())),
                       new CommandViewModel(
                    "Notatki Proejktu ",
                    new BaseCommand(() =>  this.ShowWorkspace<NotatkiWindowViewModel>())),
                       new CommandViewModel(
                    "Wszystkie Budzety ",
                    new BaseCommand(() =>  this.ShowWorkspace<OpenBUdzetViewModel>())),
                          new CommandViewModel(
                    "Pliki Projektu",
                    new BaseCommand(() =>  this.ShowWorkspace<PlikiWindowViewModel>())),
                    //         new CommandViewModel(
                    //"PodsumowanieCzasuProjektu",
                    //new BaseCommand(() =>  this.ShowWorkspace<PodsumowanieWindowViewModel>())),
                                new CommandViewModel(
                    "Zadanie Projektu",
                    new BaseCommand(() =>  this.ShowWorkspace<ZadaniaWindowViewModel>())),
                    

                    // new CommandViewModel(
                    //"Logi Zadan",
                    //new BaseCommand(() =>  this.ShowWorkspace<LogiZadaniaViewModel>())),
                       new CommandViewModel(
                    "Eventy",
                    new BaseCommand(() =>  this.ShowWorkspace<WszystkieEventyViewModel>())),

                new CommandViewModel(
                    "Nowy Event ",
                    new BaseCommand(() => this.CreateView(new NowyEventViewModel() ))),
                new CommandViewModel(
                    "Eventy Notatki",
                    new BaseCommand(() =>  this.ShowWorkspace<NotatkiWindowEventViewModel>())),
                 new CommandViewModel(
                    "Eventy Pliki",
                    new BaseCommand(() =>  this.ShowWorkspace<ZadaniaWindowEventViewModel>())),

                 new CommandViewModel(
                    "Dodaj Event Notatka",
                    new BaseCommand(() => this.CreateView(new DodajNotatkeEventViewModel()))),

                 new CommandViewModel(
                    "Dodaj Event Plik",
                    new BaseCommand(() => this.CreateView(new DodajPlikEventViewModel()))),










            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers

        private void CreateView(WorkspaceViewModel nowy)
        {
            this.Workspaces.Add(nowy);
            this.SetActiveWorkspace(nowy);
        }
        private void ShowWorkspace<T>() where T : WorkspaceViewModel, new()
        {
            T workspace = this.Workspaces.FirstOrDefault(vm => vm is T) as T;
            if (workspace == null)
            {
                workspace = new T();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        private void open(string name)
        {
           
            if (name== "ProjektyALL")
                    ShowWorkspace<WszystkieProjektyViewModel>();
            if(name == "EventyALL")
                ShowWorkspace<WszystkieEventyViewModel>();
            if(name == "ProjektyADD")
                CreateView(new NowyProjektViewModel());
            if (name == "WydarzeniaADD")
                CreateView(new NowyEventViewModel());
        }
        
        #endregion
    }
}
