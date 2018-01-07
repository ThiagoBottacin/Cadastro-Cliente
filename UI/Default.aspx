<%@ Page Title="Cadastro de Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.13/jquery.mask.min.js"></script>
    <script src="Scripts/Pages/Default/default.js"></script>

    <div class="container gap-large">
        <div class="row">

            <div class="col-md-10 col-md-offset-1">
                <asp:UpdatePanel ID="upGdCliente" runat="server">
                    <ContentTemplate>

                        <asp:HiddenField runat="server" ID="hfClienteId" ClientIDMode="Static" />

                        <asp:GridView ID="gdCliente" runat="server" HorizontalAlign="Center" DataKeyNames="ClienteId" OnRowCommand="gdCliente_OnRowCommand" AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-hover table-striped">
                            <Columns>

                                <asp:BoundField DataField="ClienteId" HeaderText="ID" Visible="False" />
                                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                                <asp:BoundField DataField="Cpf" HeaderText="Cpf" />
                                <asp:BoundField DataField="TipoCliente.Nome" HeaderText="Tipo" />
                                <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                                <asp:BoundField DataField="SituacaoCliente.Nome" HeaderText="Situação" />

                                <asp:ButtonField CommandName="EditRow"
                                    ControlStyle-CssClass="btn btn-info"
                                    ButtonType="Button" Text="Editar" HeaderText="Editar">
                                    <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                </asp:ButtonField>
                                <asp:ButtonField CommandName="DeleteRow"
                                    ControlStyle-CssClass="btn btn-info"
                                    ButtonType="Button" Text="Excluir" HeaderText="Excluir">
                                    <ControlStyle CssClass="btn btn-info delete"></ControlStyle>
                                </asp:ButtonField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div>
                                    <h2>Nenhum registro encontrado.</h2>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        
                        <div class="row">
                            <div class="col-md-2 col-md-offset-5">
                                <asp:Button ID="btnCadastrar"
                                            Text="Cadastrar" CssClass="form-control btn btn-info" runat="server" OnClick="btnCadastrar_OnClick" />
                            </div>
                        </div>
                        
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <!-- Add/Edit Cliente Modal-->

    <div id="addModal" class="modal">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:UpdatePanel ID="upAdd" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"
                                aria-hidden="true">
                                ×</button>
                            <label id="addModalLabel">Dados do Cliente</label>
                        </div>

                        <div class="modal-body">
                            <div class="form-group">

                                <div class="row">
                                    <div class=" col-md-12">
                                        <label for="txtNome">Nome:</label>
                                        <asp:TextBox ID="txtNome" ClientIDMode="Static" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNome" SetFocusOnError="True"  ErrorMessage="* Obrigatório" ValidationGroup="Cliente"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class=" col-md-8">
                                        <label for="txtCpf">CPF:</label>
                                        <asp:TextBox ID="txtCpf" ClientIDMode="Static" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCpf" SetFocusOnError="True"  ErrorMessage="* Obrigatório" ValidationGroup="Cliente"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class=" col-md-4">
                                        <label for="ddlSexo">Sexo:</label>
                                        <asp:DropDownList ID="ddlSexo" ClientIDMode="Static" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlSexo" SetFocusOnError="True"  ErrorMessage="* Obrigatório" ValidationGroup="Cliente" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class=" col-md-6">
                                        <label for="ddlTipoCliente">Tipo de Cliente:</label>
                                        <asp:DropDownList ID="ddlTipoCliente" ClientIDMode="Static" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTipoCliente" SetFocusOnError="True"  ErrorMessage="* Obrigatório" ValidationGroup="Cliente" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class=" col-md-6">
                                        <label for="ddlSituacaoCliente">Situação:</label>
                                        <asp:DropDownList ID="ddlSituacaoCliente" ClientIDMode="Static" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlSituacaoCliente" SetFocusOnError="True"  ErrorMessage="* Obrigatório" ValidationGroup="Cliente" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnSave" runat="server" Text="Salvar" ClientIDMode="Static"
                                CssClass="btn btn-info" OnClick="btnSave_OnClick" ValidationGroup="Cliente"/>
                            <button class="btn btn-info" data-dismiss="modal"
                                aria-hidden="true">
                                Fechar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <!-- Add/Edit Cliente Modal-->

    <!-- Add/Edit Cliente Modal-->

    <div id="delModal" class="modal">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:UpdatePanel ID="upDel" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"
                                aria-hidden="true">
                                ×</button>
                            <asp:Label runat="server" ID="Label1" Text="Deletar Registro"></asp:Label>
                        </div>

                        <div class="modal-body">
                            <label>Deseja realmente deletar este registro?</label>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnDelete" runat="server" Text="Deletar" CssClass="btn btn-info" OnClick="btnDelete_OnClick" />
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Add/Edit Cliente Modal-->

</asp:Content>
