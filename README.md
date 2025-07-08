# ManagementApp

**ManagementApp** is a desktop application designed to help users manage projects, events, tasks, notes, files, and more. The application is built with C# and uses WPF for the user interface. Its main goal is to provide a comprehensive environment for tracking all aspects of project management, including event scheduling, deadline tracking, time logs, budgets, risks, and task histories.

## Features

- **Project Management**
  - Create, view, and edit projects.
  - Add notes and attachments to projects.
  - Manage project risks and budgets.
  - Assign tags to projects for better organization.

- **Event Management**
  - Add, view, and manage events.
  - Attach files and notes to events.
  - Track event history and changes.
  - Assign tags to events.

- **Task Management**
  - Create and manage tasks within projects.
  - Track task status, actions, and history.
  - Assign tags to tasks.

- **Time Tracking & Summaries**
  - Log work time on projects and tasks.
  - View summaries of time spent across projects or within a selected period.
  - Generate reports and visual summaries (charts/graphs) for project activities.

- **Attachments & Notes**
  - Add files and notes to both projects and events.
  - View and manage all attachments and notes.

- **Database Structure**
  - Projects, events, tasks, notes, files, time logs, project history, time summaries, tags, budgets, and risks are all stored in a well-structured database.

## Database Overview

The application uses several core tables:

- **Projects**: Project information
- **ProjectNotes**: Notes related to projects
- **ProjectFiles**: Files attached to projects
- **Events**: Events related to projects
- **EventNotes**: Notes for events
- **EventFiles**: Files for events
- **WorkLogs**: Time logs for project work
- **ProjectHistory**: Audit trail of changes made to projects
- **TimeTracking/TimeSummary**: Records and summarizes work time
- **Tasks**: Tasks within projects
- **Tags**: Tags for categorizing projects, tasks, and events
- **Budgets/Risks**: Budget and risk management for projects

## Example Entities

**Project Entity:**
```csharp
public class InfoProjekt
{
    public string NazwaProjektu { get; set; }
    public string SrodkiZapobiegawcze { get; set; }
    public string Prawdopodobienstwo { get; set; }
    public string Wplyw { get; set; }
    public string Opis { get; set; }
    public double CzasSpedzony { get; set; }
    public DateTime DataPomiaruCzasu { get; set; }
    public string tresc { get; set; }
    public DateTime DataUtworzeniaNotatki { get; set; }
    public double CalkowityBudzet { get; set; }
}
```

**Task Entity:**
```csharp
public class ZadanieInfo
{
    public string NazwaZadanie { get; set; }
    public string DzialanieZadanie { set; get; }
    public string StatusPrzedZadanie { set; get; }
    public string StatusPoZadanie { set; get; }
    public DateTime DataZmiany { set; get; }
}
```

## Usage Highlights

- **Add/View Projects and Events:** Quickly create new projects or events, add relevant files and notes, and review their detailed histories.
- **Summaries and Reports:** Use built-in summary windows to visualize project data, including time breakdowns and project status.
- **Validation:** Fields like project name and description are validated for uniqueness and completeness.

## Example Flow

- Add a new project or event using the respective forms.
- Attach files or notes as needed.
- Log work time and update task statuses.
- Use summary windows to review time spent and generate reports.
- View project or event history to audit changes.

## Getting Started

To run or build the application:
1. Clone the repository.
2. Open the solution in Visual Studio.
3. Restore NuGet packages.
4. Build and run the project (`ProjectManagementApp`).

## Contributing

Feel free to fork this repository and submit pull requests for new features or bug fixes.



---

**Project created by:** DziedzicFilip
