using apiBolao.Model;
using System;

namespace apiBolao.Api_BLL;
public class PartidasBLL
{
    private Api_DAL.PartidasDAL _DAL;

    public PartidasBLL()
    {
        _DAL = new Api_DAL.PartidasDAL();
    }

    public List<Partidas> GetAllItens()
    {
        return _DAL.GetAllItens();
        
    }

    public List<PartidaComTimes> GetItemId(int oItemId)
    {
        var data = _DAL.GetItemId(oItemId);
       
        return data;
    }

    public void PostItem(Partidas oItem)
    {
        _DAL.PostItem(oItem);
    }

    public void DeleteItem(int oItemId)
    {
        _DAL.DeleteItem(oItemId);
    }

    public Partidas UpdateItem(Partidas oItem)
    {
        var data = _DAL.UpdateItem(oItem);
        if (data == null)
        {
            throw new Exception("Invalido");
        }

        return data;
    }

}
