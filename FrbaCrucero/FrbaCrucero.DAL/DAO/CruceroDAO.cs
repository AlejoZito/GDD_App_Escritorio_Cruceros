using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.DAO
{
    public class CruceroDAO : IDAO<Crucero>
    {
        public Crucero GetByID(int id)
        {
            return new Crucero()
            {
                Cod_Crucero = 1,
                Fabricante = new Fabricante()
                {
                    Cod_Fabricante = 1,
                    Detalle = "Motorola"
                },
                Modelo_Crucero = new ModeloCrucero()
                {
                    Cod_Modelo = 2,
                    Detalle = "Catamaran"
                },
                Cabinas = new List<Cabina>(){
                    new Cabina(){
                        Cod_Cabina = 2,
                        Numero = 3,
                        Piso = 1,
                        Tipo_Cabina = new TipoCabina(){
                            Cod_Tipo = 5,
                            Detalle = "Con cama"
                        }
                    }
                },
            };

        }

        public List<Crucero> GetAll()
        {
            return new List<Crucero>(){
                new Crucero(){
                    Cod_Crucero = 1,
                Fabricante = new Fabricante()
                {
                    Cod_Fabricante = 1,
                    Detalle = "Motorola"
                },
                Modelo_Crucero = new ModeloCrucero()
                {
                    Cod_Modelo = 2,
                    Detalle = "Catamaran"
                },
                Cabinas = new List<Cabina>(){
                    new Cabina(){
                        Cod_Cabina = 2,
                        Numero = 3,
                        Piso = 1,
                        Tipo_Cabina = new TipoCabina(){
                            Cod_Tipo = 5,
                            Detalle = "Con cama"
                            }
                        }
                    }
                },
                new Crucero(){
                        Cod_Crucero = 2,
                    Fabricante = new Fabricante()
                    {
                        Cod_Fabricante = 1,
                        Detalle = "A"
                    },
                    Modelo_Crucero = new ModeloCrucero()
                    {
                        Cod_Modelo = 2,
                        Detalle = "X"
                    },
                    Cabinas = new List<Cabina>(){
                        new Cabina(){
                            Cod_Cabina = 2,
                            Numero = 3,
                            Piso = 1,
                            Tipo_Cabina = new TipoCabina(){
                                Cod_Tipo = 5,
                                Detalle = "B"
                            }
                        }
                    },
                }
            };
        }

        public void Add(Crucero t)
        {

        }

        public void Edit(Crucero t)
        {
            
        }

        public void Delete(Crucero t)
        {
            throw new NotImplementedException();
        }
    }
}
