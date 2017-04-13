
using StrategySimulator.Model.Results;
using StrategySimulator.Model.Scores;
using System.Collections.Generic;

public delegate void Strategy(List<ResultBaccaratCoup> results, ScoreBaccarat scoreShoe, decimal sessionTotal, MoneyManagementShoe moneyManagementShoe, MoneyManagementBankroll moneyManagementBankroll);
public delegate OutcomesBaccaratCoup StrategyCore(int i, List<ResultBaccaratCoup> results, ScoreBaccarat scoreShoe, decimal sessionTotal, BetProgressionCore betProgression, MoneyManagementShoe moneyManagementShoe, MoneyManagementBankroll moneyManagementBankroll);