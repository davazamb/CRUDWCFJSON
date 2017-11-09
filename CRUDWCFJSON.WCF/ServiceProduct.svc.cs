using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CRUDWCFJSON.WCF.Models;

namespace CRUDWCFJSON.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceProduct" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceProduct.svc o ServiceProduct.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceProduct : IServiceProduct
    {
        public bool Create(Product product)
        {
            using (TiendaEntities ctx = new TiendaEntities())
            {
                try
                {
                    ProductEntity p = new ProductEntity();
                    p.Name = product.Name;
                    p.Price = product.Price;
                    p.Quantity = product.Quantity;
                    p.CreationDate = product.CreationDate;
                    ctx.ProductEntities.Add(p);
                    ctx.SaveChanges();
                    return true;
                }
                catch 
                {
                    return false;
                }                
               
            }
        }

        public bool Delete(Product product)
        {
            using (TiendaEntities ctx = new TiendaEntities())
            {
                try
                {
                    int id = Convert.ToInt32(product.Id);
                    ProductEntity p = ctx.ProductEntities.Single(pe => pe.Id == id);
                    ctx.ProductEntities.Remove(p);
                    ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public void DoWork()
        {
        }

        public bool Edit(Product product)
        {
            using (TiendaEntities ctx = new TiendaEntities())
            {
                try
                {
                    int id = Convert.ToInt32(product.Id);
                    ProductEntity p = ctx.ProductEntities.Single(pe=> pe.Id == id);
                    p.Name = product.Name;
                    p.Price = product.Price;
                    p.Quantity = product.Quantity;
                    p.CreationDate = product.CreationDate;
                    ctx.ProductEntities.Add(p);
                    ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public Product Find(string id)
        {
            using (TiendaEntities ctx = new TiendaEntities())
            {
                int mid = Convert.ToInt32(id);
                return ctx.ProductEntities.Where(p => p.Id == mid).Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.Value,
                    Quantity = p.Quantity.Value,
                    CreationDate = p.CreationDate.Value
                    
                }).First();
            }
        }

        public List<Product> FindAll()
        {
            using (TiendaEntities ctx = new TiendaEntities())
            {
                return ctx.ProductEntities.Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.Value,
                    Quantity = p.Quantity.Value,
                    CreationDate = p.CreationDate.Value

                }).ToList();
            }
        }
    }
}
