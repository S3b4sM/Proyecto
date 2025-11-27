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
        public bool ActualizarCliente(Clientes cliente)
        {
            return clientesRepository.ActualizarCliente(cliente);
        }
        public bool EliminarCliente(string documento)
        {
            return clientesRepository.EliminarCliente(documento);
        }
        public DataTable ObtenerClientes(int id)
        {
            return clientesRepository.MostrarClientes(id);
        }
    }
}
