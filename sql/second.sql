CREATE TABLE Dates (
    Id BIGINT,
    Dt DATE
);

WITH OrderedStates AS (
    SELECT Id, Dt, LEAD(Dt) OVER(PARTITION BY Id ORDER BY Dt) AS NextDt
    FROM Dates
)
SELECT Id, Dt as Sd, NextDt as Ed
FROM OrderedStates
WHERE NextDt IS NOT NULL
ORDER BY Id, Sd;