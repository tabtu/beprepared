// https://www.hackerrank.com/challenges/java-reflection-attributes/problem

import java.lang.reflect.*;
import java.util.*;

class Student {
    private String name;
    private String id;
    private String email;

    // public String getName() {
    // return name;
    // }
    // public String getId() {
    // return id;
    // }
    // public String getEmail() {
    // return email;
    // }
    // public void setName(String name) {
    // this.name = name;
    // }
    // public void setId(String id) {
    // this.id = id;
    // }
    // public void setEmail(String email) {
    // this.email = email;
    // }

    public void ahqym() {
        return;
    }

    public void amftc() {
        return;
    }

    public void anotherfunction() {
        return;
    }

    public void atcks() {
        return;
    }

    public void bwkbd() {
        return;
    }

    public void cfwyc() {
        return;
    }

    public void cmkxa() {
        return;
    }

    public void dnpym() {
        return;
    }

    public void dnqvo() {
        return;
    }

    public void dvvwq() {
        return;
    }

    public void ehjdm() {
        return;
    }

    public void elyed() {
        return;
    }

    public void fmyce() {
        return;
    }

    public void getEmail() {
        return;
    }

    public void getId() {
        return;
    }

    public void getName() {
        return;
    }

    public void ghtlj() {
        return;
    }

    public void hluvb() {
        return;
    }

    public void isqdf() {
        return;
    }

    public void iwhtf() {
        return;
    }

    public void jmopy() {
        return;
    }

    public void jnskt() {
        return;
    }

    public void kbjlt() {
        return;
    }

    public void kgwku() {
        return;
    }

    public void khuag() {
        return;
    }

    public void levtp() {
        return;
    }

    public void mcgme() {
        return;
    }

    public void migyc() {
        return;
    }

    public void moebl() {
        return;
    }

    public void nixhb() {
        return;
    }

    public void odyqp() {
        return;
    }

    public void ogvdl() {
        return;
    }

    public void ormim() {
        return;
    }

    public void piwro() {
        return;
    }

    public void plaob() {
        return;
    }

    public void pnruo() {
        return;
    }

    public void pqfct() {
        return;
    }

    public void ptrup() {
        return;
    }

    public void pvgyp() {
        return;
    }

    public void qthde() {
        return;
    }

    public void rmjig() {
        return;
    }

    public void setEmail() {
        return;
    }

    public void setId() {
        return;
    }

    public void setName() {
        return;
    }

    public void sumvl() {
        return;
    }

    public void tkbpp() {
        return;
    }

    public void tntpj() {
        return;
    }

    public void toxdp() {
        return;
    }

    public void twyfa() {
        return;
    }

    public void uccfq() {
        return;
    }

    public void ujxei() {
        return;
    }

    public void vhxoi() {
        return;
    }

    public void viwuu() {
        return;
    }

    public void viyog() {
        return;
    }

    public void whjtj() {
        return;
    }

    public void ytijy() {
        return;
    }
}

class Solution {

    public static void main(String[] args) {
        Class student = Student.class;
        Method[] methods = student.getDeclaredMethods();

        ArrayList<String> methodList = new ArrayList<>();
        for (int i = 0; i < methods.length; i++) {
            methodList.add(methods[i].getName());
        }
        Collections.sort(methodList);
        for (String name : methodList) {
            System.out.println(name);
        }
    }

}
