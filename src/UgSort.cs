
using System.Collections;
using System.Collections.Generic;



namespace EliErkin
{
    /// <summary>
    /// Sorting Algorthm for Uyghur Script
    /// </summary>
    public class UgSort : IComparer<string>, IComparer
    {
        private const int BPAD = 0x0600;
        private const int BMAX = 0x06FF;
        private const int HAMZA = 1574;

        /// <summary>
        /// Uyghur alphabet order
        /// </summary>
        private const string alphabet = "اەبپتجچخدرزژسشغفقكگڭلمنھوۇۆۈۋېىي";

        /// <summary>
        /// compare two object
        /// </summary>
        /// <param name="objA">Object One</param>
        /// <param name="objB">Object Two</param>
        /// <returns>result 1/0/-1</returns>
        public int Compare(object objA, object objB)
        {

            return compareString((string)objA, (string)objB);
        }

        /// <summary>
        ///Compare two string
        /// </summary>
        /// <param name="strA">string one </param>
        /// <param name="strB">string two</param>
        /// <returns>result 1/0/-1</returns>
        private int compareString(string strA, string strB)
        {
            int MAX = strA.Length + strB.Length;
            int i = 0;
            int j = 0;
            int sHamza = MAX;
            int dHamza = MAX;
            char sChr, dChr;

            while (i < strA.Length && j < strB.Length)
            {
                sChr = strA[i];
                dChr = strB[j];

                #region Hamza
                /* HAMZA normally does not affect the alphabetical order. 
                  * if two strings differ by a HAMZA, such as "suret" and "sur'et", the one with
                  * HAMZA would be alphebetically smaller.
                  */
                if (sChr == HAMZA && dChr == HAMZA)
                {
                    i++;
                    j++;
                    continue;
                }
                else if (sChr == HAMZA)
                {
                    if (sHamza == MAX)
                    {
                        sHamza = i;
                    }
                    i++;
                    continue;
                }
                else if (dChr == HAMZA)
                {
                    if (dHamza == MAX)
                    {
                        dHamza = j;
                    }
                    j++;
                    continue;
                }

                #endregion

                if (BPAD <= sChr && sChr <= BMAX
                  && BPAD <= dChr && dChr <= BMAX
                  && alphabet.IndexOf(sChr) > -1
                  && alphabet.IndexOf(dChr) > -1
                  )
                {

                    int sAlpha = alphabet.IndexOf(sChr);
                    int dAlpha = alphabet.IndexOf(dChr);
                    if (sAlpha < dAlpha)
                    {
                        return -1;
                    }
                    else if (sAlpha > dAlpha)
                    {
                        return 1;
                    }
                }
                else
                {//for non-Uyghur letters
                    if (sChr < dChr)
                    {
                        return -1;
                    }
                    else if (sChr > dChr)
                    {
                        return 1;
                    }
                }
                i++;
                j++;
            }

            // end at least one of the strings
            // length more ones to ranked alphabetically higher.
            if (i == strA.Length && j < strB.Length)
            {
                return -1;
            }
            else if (i < strA.Length && j == strB.Length)
            {
                return 1;
            }


            //Hamza condition
            if (sHamza < dHamza)
            {
                return -1;
            }
            else if (sHamza > dHamza)
            {
                return 1;
            }

            return 0;


        }

        /// <summary>
        /// string compare interface
        /// </summary>
        /// <param name="strA"></param>
        /// <param name="strB"></param>
        /// <returns>result 1/0/-1</returns>
        public int Compare(string strA, string strB)
        {
            return compareString(strA, strB);
        }

        /// <summary>
        /// Sorting string array
        /// </summary>
        /// <param name="asText">string array</param>
        /// <returns>sorted string array</returns>
        public string[] Sort(string[] asText)
        {
            for (int i = 0; i < asText.Length - 2; i++)
            {
                int rv = this.compareString(asText[i], asText[i + 1]);
                if (rv > 0)//swap two string
                {
                    string temp = asText[i + 1];
                    asText[i + 1] = asText[i];
                    asText[i] = temp;
                }
            }
            return asText;
        }
    }
}
