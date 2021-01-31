using FootballChampionship.Domain.Model;
using FootballChampionship.Domain.Services.Abstract;
using System;

namespace FootballChampionship.Domain.Services.Implementation
{
    class MatchResultGatherer : IMatchResultGatherer
    {
        private const string START_MESSAGE = "******* Please enter results for every match held during the championships *******";
        private const string MATCH_DESCRIPTION = "------- {0} vs {1} -------";
        private const string RESULT_INSTRUCTIONS = "How did the match end? (Enter {0} for draw, {1} otherwise)";
        private const string CHOOSE_WINNER_TEXT = "Which team won the match? Enter 1 for {0} and 2 for {1}";
        private const string INVALID_INPUT = "Please provide valid input";

        private const int RESULT_DRAW = 0;
        private const int RESULT_WIN_LOSS = 1;

        private readonly IRepository Repository;

        public MatchResultGatherer(IRepository repository)
        {
            Repository = repository;
        }


        public void InformUser()
        {
            Console.WriteLine(START_MESSAGE);
        }


        public void CreateMatchResultFromUserInput(Match match)
        {
            Console.WriteLine(string.Format(MATCH_DESCRIPTION, match.FirstTeam.Name, match.SecondTeam.Name));

            MatchResultType result = GetMatchResult();
            Team winningTeam = null;
            if (result == MatchResultType.VICTORY)
            {
                winningTeam = GetWinningTeam(match);
            }

            Repository.SaveMatchResult(match.MatchId, result, winningTeam);
        }


        private Team GetWinningTeam(Match match)
        {
            Console.WriteLine(string.Format(CHOOSE_WINNER_TEXT, match.FirstTeam.Name, match.SecondTeam.Name));

            int result;
            while (true)
            {
                string userInput = Console.ReadLine();
                try
                {
                    result = Int32.Parse(userInput);
                    if (result == 1 || result == 2)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine(INVALID_INPUT);
                }
            }

            return result == 1 ? match.FirstTeam : match.SecondTeam;
        }


        private MatchResultType GetMatchResult()
        {
            Console.WriteLine(string.Format(RESULT_INSTRUCTIONS, RESULT_DRAW, RESULT_WIN_LOSS));
            while (true)
            {
                string resultString = Console.ReadLine();
                int result;
                try
                {
                    result = Int32.Parse(resultString);
                    return result == RESULT_DRAW ? MatchResultType.DRAW : MatchResultType.VICTORY;
                }
                catch
                {
                    Console.WriteLine(INVALID_INPUT);
                }
            }
        }
    }
}
