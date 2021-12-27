/*
https://www.hackerrank.com/challenges/weather-observation-station-7

Enter your query here.
Please append a semicolon ";" at the end of the query and enter your query in a single line to avoid error.
*/



SELECT DISTINCT CITY 
FROM STATION 
WHERE RIGHT(CITY, 1) IN ('a', 'e', 'i', 'o', 'u');