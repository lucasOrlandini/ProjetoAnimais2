using Fatec.ProjetoAnimais.Models;
using System.Web;

namespace Fatec.ProjetoAnimais.Sessao
{
    public static class ControleSessao
    {
        public static PessoaViewModel UsuarioLogado
        {

            get
            {
                if (HttpContext.Current.Session["UsuarioLogado"] == null)
                {
                    HttpContext.Current.Response.Redirect("~/Login/Autenticar");
                    return null;
                }

                return (PessoaViewModel)HttpContext.Current.Session["UsuarioLogado"];
            }

            set
            {
                HttpContext.Current.Session["UsuarioLogado"] = value;
            }
        }
    }
}