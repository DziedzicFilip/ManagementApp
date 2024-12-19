using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public Projekty SelectedProject { get; set; }

        public ProjectDetailsViewModel(Projekty project)
        {
            SelectedProject = project;
        }
    }
}
