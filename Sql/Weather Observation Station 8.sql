/*
https://www.hackerrank.com/challenges/weather-observation-station-8

Oracle Version

Enter your query here.
Please append a semicolon ";" at the end of the query and enter your query in a single line to avoid error.
*/

SELECT DISTINCT CITY 
FROM STATION 
WHERE REGEXP_LIKE (UPPER(city),'^[AEIOU].*[AEIOU]$');