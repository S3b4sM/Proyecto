using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriaService
    {
        CategoriaRepository catRepo = new CategoriaRepository();
        public DataTable CargarRazon()
        {
            var dataTable = catRepo.cbxRazon();
            return dataTable;
        }
        public DataTable CargarTipos()
        {
            var dataTable = catRepo.cbxTipo();
            return dataTable;
        }
        public DataTable CatPorTipo(bool esIngreso)
        {
            return catRepo.CatPorTipo(esIngreso);
        }
    }
}
