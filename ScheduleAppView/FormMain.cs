using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleAppView
{
    public partial class FormMain : Form
    {
        private readonly ILogger _logger;

        public FormMain(ILogger<FormMain> logger)
        {
            InitializeComponent();
            _logger = logger;
        }

        private void buttonRooms_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider?.GetService(typeof(FormRooms)) as FormRooms;
            form?.ShowDialog();
        }

        private void buttonTeachers_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider?.GetService(typeof(FormTeachers)) as FormTeachers;
            form?.ShowDialog();
        }

        private void buttonSubjects_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider?.GetService(typeof(FormSubjects)) as FormSubjects;
            form?.ShowDialog();
        }

        private void buttonGroups_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider?.GetService(typeof(FormGroups)) as FormGroups;
            form?.ShowDialog();
        }

        private void buttonSchedules_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider?.GetService(typeof(FormSchedules)) as FormSchedules;
            form?.ShowDialog();
        }
    }
}
