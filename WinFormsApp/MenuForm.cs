using API.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class MenuForm : Form
    {
        private readonly string? tipoUsuario;
        private readonly int? currentUserId;
        private MisMaterias misMateriasControl;

        public MenuForm(int? userId, string? tipo)
        {
            InitializeComponent();
            currentUserId = userId;
            tipoUsuario = tipo;
        }

        private void Menu_Load(object? sender, EventArgs e)
        {
            // Configura visibilidad de botones según rol
            ConfigureForTipo();

            // Si el usuario es alumno/profesor, carga MisMaterias automáticamente
            int? idToUse = currentUserId ?? APIClientBase.CurrentUserId;
            string? tipoToUse = tipoUsuario ?? APIClientBase.CurrentUserTipo;
            if (idToUse != null && !string.IsNullOrEmpty(tipoToUse))
            {
                // fire-and-forget (es UI, mantén async/await en handlers si lo prefieres)
                _ = ShowMisMateriasAsync(idToUse.Value, tipoToUse);
            }
        }
        private void ConfigureForTipo()
        {
            string tipo = tipoUsuario?.ToLowerInvariant() ?? "admin";

            // Ejemplo: ocultar CRUDs a no-admin
            bool isAdmin = (tipo == "admin");
            btnEspecialidadesCRUD.Visible = isAdmin;
            btnPlanesCRUD.Visible = isAdmin;
            btnUsuariosCRUD.Visible = isAdmin;
            //btnModulosCRUD.Visible = isAdmin;
            btnMaterias.Visible = isAdmin;
            btnComisiones.Visible = isAdmin;

            // Cursos/MisMaterias se mantienen visibles para todos; texto según rol
            if (tipo == "alumno") btnCursos.Text = "Mis Materias";
            else if (tipo == "profesor") btnCursos.Text = "Mis Dictados";
            else btnCursos.Text = "Cursos";
        }
        // -------------------------
        // Helpers de UI / navegación
        // -------------------------
        private Panel GetContentPanel()
        {
            // Asegúrate de que el Panel en el Designer se llame "panelContent".
            var pnl = Controls.Find("panelContent", true).FirstOrDefault() as Panel;
            if (pnl == null)
            {
                // Si no existe, crea uno (opcional). Mejor: renombrar el Panel en el Designer.
                pnl = new Panel { Name = "panelContent", Dock = DockStyle.Fill };
                Controls.Add(pnl);
                pnl.BringToFront();
            }
            return pnl;
        }

        private void ReplacePanelContent(UserControl uc)
        {
            var panel = GetContentPanel();
            panel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void SetActiveButton(Button active)
        {
            // Resetea todos los botones del menú (ajusta nombres si son distintos)
            var buttons = new[] { btnEspecialidadesCRUD, btnPlanesCRUD, btnUsuariosCRUD, btnCursos, btnComisiones, btnCerrar };
            foreach (var b in buttons)
            {
                if (b == null) continue;
                b.BackColor = SystemColors.Control;
                b.ForeColor = SystemColors.ControlText;
            }

            if (active != null)
            {
                active.BackColor = Color.DimGray;
                active.ForeColor = Color.White;
            }
        }
        // -------------------------
        // Mostrar MisMaterias
        // -------------------------
        private async Task ShowMisMateriasAsync(int userId, string tipo)
        {
            try
            {
                if (misMateriasControl == null)
                    misMateriasControl = new MisMaterias();

                ReplacePanelContent(misMateriasControl);

                // marca el botón como activo (aquí usamos btnCursos para el ejemplo)
                SetActiveButton(btnCursos);

                await misMateriasControl.LoadForUserAsync(userId, tipo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando materias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al cerrar sesión: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnModulosCRUD_Click(object sender, EventArgs e)
        {
            try
            {
                MateriaListaForm matForm = new MateriaListaForm();
                matForm.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al modificar especialidad: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /*private void btnPlanesCRUD_Click(object sender, EventArgs e)
        {
            try
            {
                PlanListaForm planListaForm = new PlanListaForm();
                planListaForm.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al modificar plan: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }*/
        private void btnPlanesCRUD_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new PlanListaForm();
                SetActiveButton(btnPlanesCRUD);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        /* private void btnEspecialidadesCRUD_Click(object sender, EventArgs e)
        {
            try
            {
                EspecialidadListaForm espForm = new EspecialidadListaForm();
                espForm.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al abrir especialidades: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }*/
        private void btnEspecialidadesCRUD_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new EspecialidadListaForm();
                SetActiveButton(btnEspecialidadesCRUD);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void btnUsuariosCRUD_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioList formuser = new UsuarioList();
                formuser.ShowDialog();

            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }

        }
        /*private void btnCursos_Click(object sender, EventArgs e)
        {
            try
            {
                CursoListaForm curForm = new CursoListaForm();
                curForm.ShowDialog();
            }
            catch (Exception err)
            {
                throw new ArgumentException(err.Message);
            }
        }*/
        private async void btnCursos_Click(object sender, EventArgs e)
        {
            int? idToUse = currentUserId ?? APIClientBase.CurrentUserId;
            string? tipoToUse = tipoUsuario ?? APIClientBase.CurrentUserTipo;

            if (idToUse == null || string.IsNullOrEmpty(tipoToUse))
            {
                MessageBox.Show("Información de usuario no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await ShowMisMateriasAsync(idToUse.Value, tipoToUse);
        }
        private void btnComisiones_Click(object sender, EventArgs e)
        {
            try
            {
                ComisionListaForm comForm = new ComisionListaForm();
                comForm.ShowDialog();
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
    }
}
