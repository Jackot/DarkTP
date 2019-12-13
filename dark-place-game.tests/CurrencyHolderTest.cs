using System;
using Xunit;

namespace dark_place_game.tests
{
    
    /// Cette classe contient tout un ensemble de tests unitaires pour la classe CurrencyHolder
    public class CurrencyHolderTest
    {
        public static readonly int EXEMPLE_CAPACITE_VALIDE = 2748;
        public static readonly int EXEMPLE_CONTENANCE_INITIALE_VALIDE = 978;
        public static readonly string EXEMPLE_NOM_MONNAIE_VALIDE = "Brouzouf";

        [Fact]
        public void VraiShouldBeTrue()
        {
            var vrai = true;
            Assert.True(vrai, "Erreur, vrai vaut false. Le test est volontairement mal Ã©crit, corrigez le.");
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf10ShouldContain10Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , 10);
            var result = ch.CurrentAmount == 10;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf25ShouldContain25Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 25);
            var result = ch.CurrentAmount == 25;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf0ShouldContain0Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE, 0);
            var result = ch.CurrentAmount == 0;
            Assert.True(result);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNegativeContentThrowExeption()
        {
            // Petite subtilitÃ© : pour tester les levÃ©es d'exeption en c# on est obligÃ© d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le dÃ©tail pour dÃ©clarer une lambda respectez la syntaxe ci dessous, pour rÃ©diger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , -10);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNullNameThrowExeption()
        {
            // Petite subtilitÃ© : pour tester les levÃ©es d'exeption en c# on est obligÃ© d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le dÃ©tail pour dÃ©clarer une lambda respectez la syntaxe ci dessous, pour rÃ©diger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(null,EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithEmptyNameThrowExeption()
        {
            // Petite subtilitÃ© : pour tester les levÃ©es d'exeption en c# on est obligÃ© d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le dÃ©tail pour dÃ©clarer une lambda respectez la syntaxe ci dessous, pour rÃ©diger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder("",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        // #TODO_ETAPE_4
        [Fact]
        public void BrouzoufIsAValidCurrencyName ()
        {
            // A vous d'Ã©crire un test qui vÃ©rife qu'on peut crÃ©er un CurrencyHolder contenant une monnaie dont le nom est Brouzouf
            var ch = new CurrencyHolder("Brouzouf", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE) ;
            Assert.True(ch.CurrencyName == "Brouzouf") ;
        }

        [Fact]
        public void DollardIsAValidCurrencyName ()
        {
            // A vous d'Ã©crire un test qui vÃ©rife qu'on peut crÃ©er un CurrencyHolder contenant une monnaie dont le nom est Dollard
            var ch = new CurrencyHolder("Dollard", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE) ;
            Assert.True(ch.CurrencyName == "Dollard") ;
        }

        [Fact]
        public void TestPut10CurrencyInNonFullCurrencyHolder()
        {
            // A vous d'Ã©crire un test qui vÃ©rifie que si on ajoute via la methode put 10 currency Ã  un sac a moitÃ© plein, il contient maintenant la bonne quantitÃ© de currency
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE) ;
            ch.Store(10) ;
            Assert.True(ch.CurrentAmount == 10 + EXEMPLE_CONTENANCE_INITIALE_VALIDE) ;
        }

        [Fact]
        public void TestPut10CurrencyInNearlyFullCurrencyHolder()
        {
            // A vous d'Ã©crire un test qui vÃ©rifie que si on ajoute via la methode put 10 currency Ã  un sac quasiement plein, une exeption NotEnoughtSpaceInCurrencyHolderExeption est levÃ©e.
            Action mauvaisAppel = () => {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CAPACITE_VALIDE-9) ;
                ch.Store(10) ;
            };
            Assert.Throws<NotEnoughtSpaceInCurrencyHolderExeption>(mauvaisAppel) ;
        }

        [Fact]
        public void CreatingCurrencyHolderWithNameShorterThan4CharacterThrowExeption()
        {
            // A vous d'Ã©crire un test qui doit Ã©chouer s'il est possible de crÃ©er un CurrencyHolder dont Le Nom De monnaie est infÃ©rieur Ã  4 lettres
            Action mauvaisAppel = () => new CurrencyHolder("msn", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE) ;
            Assert.Throws<ArgumentException>(mauvaisAppel) ;
        }

        [Fact]
        public void WithdrawMoreThanCurrentAmountInCurrencyHolderThrowExeption()
        {
            // A vous d'Ã©crire un test qui vÃ©rifie que retirer (methode withdraw) une quantitÃ© negative de currency leve une exeption CantWithDrawNegativeCurrencyAmountExeption.
            // Asruce : dans ce cas prÃ©vu avant mÃªme de pouvoir compiler le test, vous allez Ãªtre obligÃ© de crÃ©er la classe CantWithDrawMoreThanCurrentAmountExeption (vous pouvez la mettre dans le meme fichier que CurrencyHolder)
            Action mauvaisAppel = () => { 
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE) ;
                ch.Withdraw(-12) ;
            } ;
            Assert.Throws<CantWithDrawNegativeCurrencyAmountExeption>(mauvaisAppel) ;
        }

        /* TEST currency doit faire entre 4 et 10 characteres : */
        [Fact]
        public void CurrencyNameMustBebeetwen4And10Char() 
        {
            Action mauvaisAppel = () => new CurrencyHolder("blblablablablablabla", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE) ;
            Assert.Throws<ArgumentException>(mauvaisAppel) ;
        }

        /* TEST : On ne peux pas mettre" put" une quantitÃ© negative de currency dans un CurrencyHolder */
        [Fact]
        public void weCannothaveaNegativeQuantityInCurrency() 
        {
            Action mauvaisAppel = () => {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE) ;
                ch.Store(-10) ;
            };
            Assert.Throws<ArgumentException>(mauvaisAppel) ;
        }

        /* TEST  On ne peux pas mettre des currency dans un CurrencyHolder si ca le fait depasser sa capacitÃ©*/
        [Fact]
        public void weCannotPutanewCurrencyIfCapacityExceed() 
        {
            Action mauvaisAppel = () => {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE) ;
                ch.Store(EXEMPLE_CAPACITE_VALIDE+10) ;
            } ;
            Assert.Throws<NotEnoughtSpaceInCurrencyHolderExeption>(mauvaisAppel) ;
        }

        /* TEST : On ne peux pas ajouter ou retirer 0 currency (lever expetion) (2 tests) */
        [Fact]
        public void weCannotStoreZeroCurrency() 
        {
            Action mauvaisAppel = () => {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE) ;
                ch.Store(0) ;
            } ;
            Assert.Throws<ArgumentException>(mauvaisAppel) ;
        }

        /* TEST Ne  pas ajouter ou retirer 0 currency (lever expetion) (2 tests) */
        [Fact]
        public void weCannotWithdrawZeroCurrency() 
        {
            Action mauvaisAppel = () => {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE) ;
                ch.Withdraw(0) ;
            } ;
            Assert.Throws<ArgumentException>(mauvaisAppel) ;
        }

        /* TEST currency ne doit pas commencer par la lettre a majuscule*/
        [Fact]
        public void currencyNameBeginWithmini() 
        {
            Action mauvaisAppel = () => new CurrencyHolder("chicago", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE) ;
            Assert.Throws<ArgumentException>(mauvaisAppel) ;
        }

        /* TEST currency ne doit pas commencer par la lettre a miniscule*/
        [Fact]
        public void currencyNameBeginWithmaj() 
        {
            Action mauvaisAppel = () => new CurrencyHolder("Miami", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE) ;
            Assert.Throws<ArgumentException>(mauvaisAppel) ;
        }

        /* TEST CurrencyHolder ne peux avoir une capacitÃ© infÃ©rieure Ã  1 (2 tests) */
        [Fact]
        public void CurrencyHolderCapacityLessThanOne() 
        {
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, -1, EXEMPLE_CONTENANCE_INITIALE_VALIDE) ;
            Assert.Throws<ArgumentException>(mauvaisAppel) ;
        }

        [Fact]
        public void CurrencyHolderCannotHadCapacityzero() 
        {
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 0, EXEMPLE_CONTENANCE_INITIALE_VALIDE) ;
            Assert.Throws<ArgumentException>(mauvaisAppel) ;
        }

        /* TEST : Faire 2 tests unitaires pertinents pour la methode IsEmpty */
        [Fact]
        public void EmptyIsZero() 
        {
            Action mauvaisAppel = () => {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 10, 0) ;
                if (ch.IsEmpty() && ch.CurrentAmount == 0)
                    throw new System.ArgumentException("The method is ok.") ;
            } ;
            Assert.Throws<ArgumentException>(mauvaisAppel) ;
        }

        [Fact]
        public void TenIsNotEmpty() 
        {
            Action mauvaisAppel = () => {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 10, 10) ;
                if (! ch.IsEmpty() && ch.CurrentAmount == 10)
                    throw new System.ArgumentException("The method is ok.") ;
            } ;
            Assert.Throws<ArgumentException>(mauvaisAppel) ;
        }
        /* TEST : Un CurrencyHolder est plein (IsFull) si son contenu est Ã©gal Ã  sa capacitÃ© (4 test, y a pas de piege)  */
        [Fact]
        public void isFullTest1() 
        {
            Action mauvaisAppel = () => {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 10, 10) ;
                if (ch.IsFull())
                    throw new System.ArgumentException("IsFull test 1 ok .") ;
            } ;
            Assert.Throws<ArgumentException>(mauvaisAppel) ;
        }
        [Fact]
        public void isFullTest2() 
        {
            Action mauvaisAppel = () => {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 12, 12) ;
                if (ch.IsFull())
                    throw new System.ArgumentException("IsFull test 2 ok .") ;
            } ;
            Assert.Throws<ArgumentException>(mauvaisAppel) ;
        }
        [Fact]
        public void isFullTest3() 
        {
            Action mauvaisAppel = () => {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 15, 15) ;
                if (ch.IsFull())
                    throw new System.ArgumentException("IsFull test 3 ok .") ;
            } ;
            Assert.Throws<ArgumentException>(mauvaisAppel) ;
        }
        [Fact]
        public void isFullTest4() 
        {
            Action mauvaisAppel = () => {
                var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 18, 18) ;
                if (ch.IsFull())
                    throw new System.ArgumentException("IsFull test 4 ok .") ;
            } ;
            Assert.Throws<ArgumentException>(mauvaisAppel) ;
        }

    }
}
