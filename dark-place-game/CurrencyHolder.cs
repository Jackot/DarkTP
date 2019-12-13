using System;

namespace dark_place_game
{

    [System.Serializable]
    /// Une Exeption Custom
    public class NotEnoughtSpaceInCurrencyHolderExeption : System.Exception {}
    public class CantWithDrawNegativeCurrencyAmountExeption : System.Exception {}
    public class CurrencyHolder
    {
        public static readonly string CURRENCY_DEFAULT_NAME = "Unnamed";

        /// Le nom de la monnaie
        public string CurrencyName {
            get {return currencyName;}
            private set {
                currencyName = value;
            }
        }
        // Le champs interne de la property
        private string currencyName = CURRENCY_DEFAULT_NAME;

        /// Le montant actuel
        public int CurrentAmount {
            get {return currentAmount;}
            private set {
                currentAmount = value;
            }
        }
        // Le champs interne de la property
        private int currentAmount = 0;

        /// La contenance maximum du conteneur
        public int Capacity {
            get {return capacity;}
            private set {
                capacity = value;
            }
        }
        // Le champs interne de la property
        private int capacity = 0;

        public CurrencyHolder(string name,int capacity, int amount) {
            if (name == "")
                throw new System.ArgumentException("Parameter name cannot be empty", "name") ;
            if (name == null)
                throw new System.ArgumentException("Parameter name cannot be null", "name") ;
            if (amount < 0)
                throw new System.ArgumentException("Parameter amount cannot be less than 0", "amount") ;
            if (name.Length < 4 || name.Length > 10)
                throw new System.ArgumentException("Parameter name cannot be less than 4 characters and less than 11 character", "name") ;
            if (name[0] == 'M')
                throw new System.ArgumentException("Parameter name begin with 'M'", "name") ;
            if (name[0] == 'c')
                throw new System.ArgumentException("Parameter name begin with 'c'", "name") ;
            if (capacity < 1)
                throw new System.ArgumentException("Parameter capacity cannot be less than 1", "capacity") ;
            CurrencyName = name;
            Capacity = capacity;
            CurrentAmount = amount;
        }

        public bool IsEmpty() {
            if (CurrentAmount == 0)
                return true ;
            return false ;
        }

        public bool IsFull() {
            if ( CurrentAmount >= Capacity )
                return true ;
            return false ;
        }

        public void Store(int amount) {
            if (amount <= 0)
                throw new System.ArgumentException("Impossible de mettre une quantite negative ou 0.", "amount") ;
            if (CurrentAmount+amount <= Capacity )
                CurrentAmount += amount ;
            else
                throw new NotEnoughtSpaceInCurrencyHolderExeption() ;
        }

        public void Withdraw(int amount) {
            if (amount < 0)
                throw new CantWithDrawNegativeCurrencyAmountExeption() ;
            if (amount == 0)
                throw new System.ArgumentException("Impossible de retirer 0.", "amount") ;
            if (CurrentAmount >= amount)
                Capacity -= amount ;
            else
                throw new System.ArgumentException("Impossible de retirer plus que le montant actuel.", "amount") ;
        }
    }
}