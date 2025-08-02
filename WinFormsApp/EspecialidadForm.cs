using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Entities;
using DTOs;
using Domain.Model;

namespace WinFormsApp
{
    public partial class EspecialidadForm : Form
    {
        public EspecialidadForm()
        {
            InitializeComponent();
        }

        private async Task Form1_Load(object sender, EventArgs e)
        {
            /*try
            {
                var especialidades = await APIEspecialidad.GetAllAsync();
            }*/
        }
    }
}
