using System;
using System.Collections.Generic;

namespace PigLatinEngine
{
    public class RuleEngine
    {
        private string[] words;
        private char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };

        public RuleEngine()
        {
            
        }
        public string[] WordSplit(string value)
        {
            words = value.Split(' ');
            return words;
        }
        public List<Rules> DetermineWordStructure(string[] words)
        {
            List<Rules> rulesToApply = new List<Rules>();
            Rules ruleCheck = new Rules();
            foreach(string word in words)
            {
                foreach(char v in vowels)
                {
                    if(!word.StartsWith(v))
                    {
                        //ruleCheck.beginsWithVowelSound = false;
                        ruleCheck.beginsWithConsonant = true;
                        //char[] clusteredConsonant = word.ToCharArray();
                        //if(clusteredConsonant[1].Equals(v))
                        //{
                        //    ruleCheck.beginsWithConsonantClusters = false;
                        //}
                        //else
                        //{
                        //    ruleCheck.beginsWithConsonantClusters = true;
                        //}
                    }
                    else
                    {
                        //ruleCheck.beginsWithVowelSound = true;
                        ruleCheck.beginsWithConsonant = false;
                        //ruleCheck.beginsWithConsonantClusters = false;
                    }
                }
                rulesToApply.Add(ruleCheck);
            }
            return rulesToApply;
        }
        public string[] WordTransform(List<Rules> rulesToApply, string[] words)
        {
            string[] transformedWords = new string[words.Length];
            int i = 0;
            foreach (string w in words)
            {
                if(rulesToApply[i].beginsWithConsonant == true)
                {
                    char[] oldWord = w.ToCharArray();
                    char[] transformation = new char[oldWord.Length + 2];
                    char firstLetter = oldWord[0];
                    for(int k = 1; k < oldWord.Length; k++)
                    {
                        transformation[k - 1] = oldWord[k];
                    }
                    transformation[transformation.Length - 3] = firstLetter;
                    transformation[transformation.Length - 2] = 'a';
                    transformation[transformation.Length - 1] = 'y';
                    String latinizedWord = new string(transformation);
                    transformedWords[i] = latinizedWord;
                }
                i++;
            }
            return transformedWords;
        }
    }
}
