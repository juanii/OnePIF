namespace OnePIF.Types
{
    public enum EMailV2POPAuthentication
    {
        unknown = -1,
        none,                   // None
        password,               // Password
        md5_challenge_response, // MD5 Challenge Response
        kerberized_pop,         // Kerberized POP
        kerberos_v4,            // Kerberos V4
        kerberos_v5,            // Kerberos V5
        ntlm                    // NTLM
    }
}
