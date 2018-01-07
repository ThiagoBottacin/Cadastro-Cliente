using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO.Entities;
using UI.WcfService;

namespace UI
{
    public partial class _Default : Page
    {
        private readonly IService1 _service = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDdlSexo();
                LoadDdlTipoCliente();
                LoadDdlSituacaoCliente();
                BindGridClientes();
            }
        }

        protected void gdCliente_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            ResetModalFields();

            int index = Convert.ToInt32(e.CommandArgument);
            hfClienteId.Value = gdCliente.DataKeys[index]?.Value.ToString();

            if (e.CommandName.Equals("EditRow"))
            {
                GridViewRow gvRow = gdCliente.Rows[index];

                txtNome.Text = HttpUtility.HtmlDecode(gvRow.Cells[1].Text);
                txtCpf.Text = HttpUtility.HtmlDecode(gvRow.Cells[2].Text);
                ddlTipoCliente.SelectedValue = ddlTipoCliente.Items.FindByText(HttpUtility.HtmlDecode(gvRow.Cells[3].Text)).Value;
                ddlSexo.SelectedValue = ddlSexo.Items.FindByText(HttpUtility.HtmlDecode(gvRow.Cells[4].Text)).Value;
                ddlSituacaoCliente.SelectedValue = ddlSituacaoCliente.Items.FindByText(HttpUtility.HtmlDecode(gvRow.Cells[5].Text)).Value;
                
                ModalManagement("addModal", "show");
            }
            else if (e.CommandName.Equals("DeleteRow"))
            {
                ModalManagement("delModal", "show");
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            var msgResult = string.Empty;
            try
            {
                int.TryParse(hfClienteId.Value, out var clienteId);
                int.TryParse(ddlTipoCliente.SelectedValue, out var tipoClienteId);
                int.TryParse(ddlSituacaoCliente.SelectedValue, out var situacaoClienteId);

                var cliente = new Cliente
                {
                    ClienteId = clienteId,
                    Nome = txtNome.Text.Trim(),
                    Cpf = txtCpf.Text.Trim(),
                    Sexo = ddlSexo.SelectedItem.Text[0],
                    TipoCliente = new TipoCliente { TipoClienteId = tipoClienteId},
                    SituacaoCliente = new SituacaoCliente { SituacaoClienteId = situacaoClienteId}
                };

                msgResult = _service.SaveCliente(cliente);
                BindGridClientes();
                ModalManagement("addModal", "hide");
            }
            catch (Exception ex)
            {
                msgResult = $"Ocorreu um erro ao salvar o registro.\\nDetalhes: {ex.Message}";
            }
            finally
            {
                Alert(msgResult);
            }
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            var msgResult = string.Empty;
            try
            {
                int.TryParse(hfClienteId.Value, out var clienteId);
                    
                msgResult = _service.DeleteCliente(clienteId);
                
                BindGridClientes();
            }
            catch (Exception ex)
            {
                msgResult = $"Ocorreu um erro ao deletar o registro.\\nDetalhes: {ex.Message}";
            }
            finally
            {
                Alert(msgResult);
                ModalManagement("delModal", "hide");
            }
        }

        protected void btnCadastrar_OnClick(object sender, EventArgs e)
        {
            ResetModalFields();
            ModalManagement("addModal", "show");
        }

        private void BindGridClientes()
        {
            try
            {
                gdCliente.DataSource = _service.GetClientes();
                gdCliente.DataBind();
            }
            catch (Exception e)
            {
                Alert($"Ocorreu um erro ao carregar os clientes.\\nDetalhes: {e.Message}");
            }
        }

        private void LoadDdlSexo()
        {
            ddlSexo.Items.Insert(0, new ListItem("Selecione...", "0"));
            ddlSexo.Items.Insert(1, new ListItem("M", "1"));
            ddlSexo.Items.Insert(2, new ListItem("F", "2"));
        }

        private void LoadDdlTipoCliente()
        {
            ddlTipoCliente.DataTextField = "Nome";
            ddlTipoCliente.DataValueField = "TipoClienteId";
            
            ddlTipoCliente.DataSource = _service.GetTipoCliente();
            ddlTipoCliente.DataBind();

            ddlTipoCliente.Items.Insert(0, new ListItem("Selecione...", "0"));
        }

        private void LoadDdlSituacaoCliente()
        {
            ddlSituacaoCliente.DataTextField = "Nome";
            ddlSituacaoCliente.DataValueField = "SituacaoClienteId";

            ddlSituacaoCliente.DataSource = _service.GetSituacaoCliente();
            ddlSituacaoCliente.DataBind();

            ddlSituacaoCliente.Items.Insert(0, new ListItem("Selecione...", "0"));
        }

        private void ResetModalFields()
        {
            hfClienteId.Value = "";
            txtNome.Text = string.Empty;
            txtCpf.Text = string.Empty;
            ddlTipoCliente.SelectedIndex = 0;
            ddlSexo.SelectedIndex = 0;
            ddlSituacaoCliente.SelectedIndex = 0;
        }

        private void ModalManagement(string modalId, string command)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), $"{command}_{modalId}", $"$('#{modalId}').modal('{command}');", true);
        }

        private void Alert(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Alerta", $"alert('{message}');", true);
        }
    }
}
