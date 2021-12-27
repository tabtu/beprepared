/*
https://www.hackerrank.com/challenges/weather-observation-station-13

Enter your query here.
Please append a semicolon ";" at the end of the query and enter your query in a single line to avoid error.
*/

SELECT ROUND(SUM(LAT_N),4)
FROM STATION 
WHERE LAT_N BETWEEN 38.7880 AND 137.2345;