using apiBolao.Model;
using System;

namespace apiBolao.Api_BLL;
public class TramitacaoRodadaBLL
{
    private Api_DAL.TramitacaoRodadaDAL _DAL;

    public TramitacaoRodadaBLL()
    {
        _DAL = new Api_DAL.TramitacaoRodadaDAL();
    }

    public List<TramitacaoRodada> GetAllItens()
    {
        return _DAL.GetAllItens();
        
    }

    public List<TramitacaoRodada> GetItemIdBolaoList(int oItemId)
    {
        var data = _DAL.GetItemIdBolaoList(oItemId);

        return data;
    }

    public TramitacaoRodada GetItemId(int oItemId)
    {
        var data = _DAL.GetItemId(oItemId);
       
        return data;
    }

    public TramitacaoRodada GetItemIdBolao(int oItemId)
    {
        var data = _DAL.GetItemIdBolao(oItemId);

        return data;
    }

    public void PostItem(TramitacaoRodada oItem)
    {
        _DAL.PostItem(oItem);
    }

    public void DeleteItem(int oItemId)
    {
        _DAL.DeleteItem(oItemId);
    }

    public TramitacaoRodada UpdateItem(TramitacaoRodada oItem)
    {
        var data = _DAL.UpdateItem(oItem);
        if (data == null)
        {
            throw new Exception("Invalido");
        }

        return data;
    }

}
