<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="InicioMedicus.aspx.cs" Inherits="CapaPresentacion.InicioMedicus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                        <h1 class="h3 mb-0 text-gray-800">Inicio</h1>
                    </div>
    <div class="row">

        <!-- Total de ventas -->
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                Total de Proyectos
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800" id="totalProyecto">4</div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-shopping-basket fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Total de Ingresos -->
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-success shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                Usuarios Registrados
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800" id="totalUsuarios">2</div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-dollar-sign fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Total de Productos -->
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-info shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                Total de tareas
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800" id="totalTareas">3</div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-clipboard-list fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <!-- Total de Categorias -->
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-warning shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">
                                Total de Transaciones
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800" id="totalTransacciones">27</div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-tags fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Pie Chart - Productos más vendidos-->
                        <div class="col-xl-5 col-lg-5">
                            <div class="card shadow mb-9">
                                <!-- Card Header - Dropdown -->
                                <div class="card-header py-3 bg-second-primary">
                                    <h6 class="m-0 font-weight-bold text-white">Transacciones Realizadas</h6>
                                </div>
                                <!-- Card Body -->
                                <div class="card-body">
                                    <div class="chart-pie" style="height: 350px !important ;">
                                        <canvas id="charProductos"></canvas>
                                    </div>
                                </div>
                            </div>
                        </div>
        <!-- Area Chart - Ventas de los ultimos 7 días -->
                        <div class="col-xl-7 col-lg-7">
                            <div class="card shadow mb-4">
                                <!-- Card Header - Dropdown -->
                                <div class="card-header py-3 bg-second-primary">
                                    <h6 class="m-0 font-weight-bold text-white">Tareas Realizadas en el ultimo semestre</h6>
                                </div>
                                <!-- Card Body -->
                                <div class="card-body">
                                    <div class="chart-area" style="height: 350px !important;">
                                        <canvas id="charVentas"></canvas>
                                    </div>
                                </div>
                            </div>
                        </div>
    </div>
    <script src="vendor/chart.js/Chart.min.js"></script>
    <script src="js/vistas/chart-pie-demo.js"></script>
    <script src="js/vistas/chart-bar-demo.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
