/*
https://www.hackerrank.com/challenges/print-prime-numbers

Oracle

Enter your query here.
Please append a semicolon ";" at the end of the query and enter your query in a single line to avoid error.
*/

SET SERVEROUTPUT ON;
DECLARE
    COUNTER NUMBER;
    K NUMBER;
    RESULT CLOB;
BEGIN
    RESULT := '';
    FOR N IN 2..1000 LOOP
    COUNTER := 0;
    K := FLOOR(N/2);
    FOR i IN 2..K LOOP
        IF(MOD(N,i)=0) THEN
          COUNTER :=1;
        END IF;
    END LOOP;
    IF (COUNTER = 0) THEN
       RESULT := RESULT||N||'&';
    END IF;
    END LOOP;
    DBMS_OUTPUT.PUT_LINE(SUBSTR(RESULT,0,length(RESULT)-1));
END;
/