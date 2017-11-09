using CRUDWCFJSON.WCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CRUDWCFJSON.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceProduct" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceProduct
    {
        [OperationContract]
        [WebInvoke(Method ="GET", UriTemplate ="findall", ResponseFormat = WebMessageFormat.Json)]
        List<Product> FindAll();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "find/{id}", ResponseFormat = WebMessageFormat.Json)]

        Product Find(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "create", ResponseFormat = WebMessageFormat.Json, RequestFormat =WebMessageFormat.Json)]

        bool Create(Product product);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "edit", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]

        bool Edit(Product product);
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delete", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]

        bool Delete(Product product);
    }
}
