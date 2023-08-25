using Bolao_API_MODEL;
using System;

namespace Bolao_API_BLL;
public class ApostasPartidasBLL
{
    private Bolao_API_DAL.ApostasPartidasDAL _DAL;

    public ApostasPartidasBLL()
    {
        _DAL = new Bolao_API_DAL.ApostasPartidasDAL();
    }

    public List<ApostasPartidas> GetAllItens()
    {
        return _DAL.GetAllItens();
        
    }

    public List<ResultadoAposta> GetItemId(int oItemId)
    {
        var data = _DAL.GetItemId(oItemId);
       
        return data;
    }

    public void PostItem(IEnumerable<ApostasPartidas> oItem)
    {
        _DAL.PostItem(oItem);
    }

    public void DeleteItem(int oItemId)
    {
        _DAL.DeleteItem(oItemId);
    }

    public ApostasPartidas UpdateItem(ApostasPartidas oItem)
    {
        var data = _DAL.UpdateItem(oItem);
        if (data == null)
        {
            throw new Exception("Invalido");
        }

        return data;
    }

}
