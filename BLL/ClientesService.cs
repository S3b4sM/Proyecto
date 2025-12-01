using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClientesService
    {
        public ClientesService() { }
        ClientesRepository clientesRepository = new ClientesRepository();
        public bool AggClientes(Clientes cliente)
        {
            return clientesRepository.AggClientes(cliente);
        }
        public bool ActualizarCliente(Clientes clientes)
        {
            return clientesRepository.ActualizarCliente(clientes);
        }
        public bool EliminarCliente(int documento)
        {
            return clientesRepository.EliminarCliente(documento);
        }
        public DataTable ObtenerClientes(int id)
        {
            return clientesRepository.MostrarClientes(id);
        }
        public int ContarClientes(int id_user)
        {
            return clientesRepository.ContarClientes(id_user);
        }
        public int ClientesMes(int id_user)
        {
            return clientesRepository.ClientesMensuales(id_user);
        }
    }
}
