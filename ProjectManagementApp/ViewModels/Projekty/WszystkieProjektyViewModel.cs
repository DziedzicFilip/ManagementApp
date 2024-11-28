using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ProjectManagementApp.Models.Entities;

namespace ProjectManagementApp.ViewModels
{
    public class WszystkieProjektyViewModel : WorkspaceViewModel
    {
        #region Fields
        private readonly ZarzadanieProjektami2Entities zarzadanieProjektami2Entities;
        #endregion
        #region Properties

        #endregion
        #region Constructor
        public WszystkieProjektyViewModel()
        {
            base.DisplayName = "Projkety";

        }
        #endregion
        #region Helpers

        #endregion

    }
}