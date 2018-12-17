namespace OnePIF.Types
{
    public enum CreditCardType
    {
        unknown = -1,
        mc,             // MasterCard
        visa,           // VISA
        amex,           // American Express
        diners,         // Diners Club
        carteblanche,   // Carte Blanche
        discover,       // Discover
        jcb,            // JCB
        solo,           // Solo
        @switch,        // Switch
        maestro,        // Maestro
        visaelectron,   // Visa Electron
        laser,          // Laser
        unionpay        // Union Pay
    }
}
