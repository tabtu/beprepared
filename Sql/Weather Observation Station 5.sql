/*
https://www.hackerrank.com/challenges/weather-observation-station-5

Enter your query here.
Please append a semicolon ";" at the end of the query and enter your query in a single line to avoid error.
*/

SELECT CITY || ' ' || LENGTH 
FROM (
SELECT CITY , LENGTH(CITY) AS LENGTH
FROM STATION 
WHERE LENGTH(CITY) = (SELECT MAX(LENGTH(CITY)) FROM STATION) 
ORDER BY CITY ) 
WHERE ROWNUM <= 1
UNION
SELECT CITY || ' ' || LENGTH 
FROM (
SELECT CITY , LENGTH(CITY) AS LENGTH
FROM STATION 
WHERE LENGTH(CITY) = (SELECT MIN(LENGTH(CITY)) FROM STATION) 
ORDER BY CITY ) 
WHERE ROWNUM <= 1 ;



-- MSSQL SERVER
/*
Enter your query here.
Please append a semicolon ";" at the end of the query and enter your query in a single line to avoid error.
*/
SELECT TOP 1 CITY, LEN(CITY)
FROM STATION
WHERE LEN(CITY) = (
    SELECT MAX(LEN(CITY)) 
    FROM STATION)
ORDER BY CITY

SELECT TOP 1 CITY, LEN(CITY)
FROM STATION
WHERE LEN(CITY) = (
    SELECT MIN(LEN(CITY)) 
    FROM STATION)
ORDER BY CITY