/*
https://www.hackerrank.com/challenges/weather-observation-station-20

Enter your query here.
Please append a semicolon ";" at the end of the query and enter your query in a single line to avoid error.
*/

SELECT CAST(LAT_N AS DECIMAL (7,4))
FROM (SELECT LAT_N, ROW_NUMBER() OVER (ORDER BY LAT_N) as ROWNU FROM STATION) AS X
WHERE ROWNU = (SELECT ROUND((COUNT(LAT_N)+1)/2, 0) FROM STATION);