using Bolao_API_MODEL;
using System;

namespace Bolao_API_BLL;
public class CampeonatosBLL
{
    private Bolao_API_DAL.CampeonatosDAL _DAL;

    public CampeonatosBLL()
    {
        _DAL = new Bolao_API_DAL.CampeonatosDAL();
    }

    public List<Campeonatos> GetAllItens()
    {
        return _DAL.GetAllItens();
        
    }

    public Campeonatos GetItemId(int oItemId)
    {
        var data = _DAL.GetItemId(oItemId);
       
        return data;
    }

    public void PostItem(Campeonatos oItem)
    {
        _DAL.PostItem(oItem);
    }

    public void DeleteItem(int oItemId)
    {
        _DAL.DeleteItem(oItemId);
    }

    public Campeonatos UpdateItem(Campeonatos oItem)
    {
        var data = _DAL.UpdateItem(oItem);
        if (data == null)
        {
            throw new Exception("Invalido");
        }

        return data;
    }

}
