using System;
using System.Collections.Generic;

namespace Breakthrough
{
    class Lock
    {
        protected List<Challenge> Challenges = new List<Challenge>();

        public bool PeekUsed { get; set; } // task 2

        public virtual void AddChallenge(List<string> condition)
        {
            Challenge C = new Challenge();
            C.SetCondition(condition);
            Challenges.Add(C);
        }

        private string ConvertConditionToString(List<string> c)
        {
            string ConditionAsString = "";
            for (int Pos = 0; Pos <= c.Count - 2; Pos++)
            {
                ConditionAsString += c[Pos] + ", ";
            }
            ConditionAsString += c[c.Count - 1];
            return ConditionAsString;
        }

        public virtual string GetLockDetails(CardCollection Sequence)
        {
            string LockDetails = Environment.NewLine + "CURRENT LOCK" + Environment.NewLine + "------------" + Environment.NewLine;
            foreach (var C in Challenges)
            {
                if (C.GetMet())
                {
                    LockDetails += "Challenge met: ";
                }
                else
                {
                    // task 8
                    List<string> ChallengeConditions = C.GetCondition();
                    if (Sequence.GetNumberOfCards() > 0 && ChallengeConditions.Count == 2 && ChallengeConditions[0] == Sequence.getAllCards()[^1].GetDescription())
                    {
                        LockDetails += "Partially met: ";
                    } 
                    else if (Sequence.GetNumberOfCards() > 1 && ChallengeConditions.Count == 3 && ChallengeConditions[0] == Sequence.getAllCards()[^2].GetDescription() && ChallengeConditions[1] == Sequence.getAllCards()[^1].GetDescription())
                    {
                        LockDetails += "Partially met: ";
                    }
                    
                    else
                    {
                        LockDetails += "Not met:       ";
                    }
                }
                LockDetails += ConvertConditionToString(C.GetCondition()) + Environment.NewLine;
            }
            LockDetails += Environment.NewLine;
            return LockDetails;
        }

        public virtual bool GetLockSolved()
        {
            foreach (var C in Challenges)
            {
                if (!C.GetMet())
                {
                    return false;
                }
            }
            return true;
        }

        public virtual bool CheckIfConditionMet(string sequence)
        {
            foreach (var C in Challenges)
            {
                if (!C.GetMet() && sequence == ConvertConditionToString(C.GetCondition()))
                {
                    C.SetMet(true);
                    return true;
                }
            }
            return false;
        }

        public virtual void SetChallengeMet(int pos, bool value)
        {
            Challenges[pos].SetMet(value);
        }

        public virtual bool GetChallengeMet(int pos)
        {
            return Challenges[pos].GetMet();
        }

        public virtual int GetNumberOfChallenges()
        {
            return Challenges.Count;
        }


    }
}