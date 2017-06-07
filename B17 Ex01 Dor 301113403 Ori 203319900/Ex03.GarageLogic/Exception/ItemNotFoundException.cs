using System;

namespace Ex03.GarageLogic
{
    public class ItemNotFoundException : System.Exception
    {
        object m_MissingItem;

        public ItemNotFoundException(System.Exception i_InnerException, object i_MissingItem)
            : base(string.Format("Error: The following item was not found: {0}", i_MissingItem.ToString()), i_InnerException)
        {
            m_MissingItem = i_MissingItem;
        }

        public ItemNotFoundException(object i_MissingItem)
            : base(string.Format("Error: The following item was not found: {0}", i_MissingItem.ToString()))
        {
            m_MissingItem = i_MissingItem;
        }
    }
}
