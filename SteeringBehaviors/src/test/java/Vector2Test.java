import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class Vector2Test {

    public Vector2 u = new Vector2();
    public Vector2 v = new Vector2();

    @BeforeEach
    public void before() {
        u.setX(20);
        u.setY(21);

        v.setX(3);
        v.setY(4);
    }

    @Test
    public void zeroTest() {
        v.zero();
        assertEquals(v.getX(), 0);
        assertEquals(v.getY(), 0);
    }

    @Test
    public void isZeroTest() {
        assertFalse(v.isZero());

        v.setX(0);
        v.setY(0);
        assertTrue(v.isZero());
    }

    @Test
    public void lengthTest() {
        assertEquals(v.length(), 5);
        assertEquals(u.length(), 29);
    }

    @Test
    public void lengthSqTest() {
        assertEquals(v.lengthSq(), 25);
        assertEquals(u.lengthSq(), 841);
    }

    @Test
    public void normalizeTest() {
        v.normalize();
        assertEquals(v.getX(), 0.6);
        assertEquals(v.getY(), 0.8);

        u.normalize();
        double a = Math.floor(u.getX() * 100000);
        double b = Math.floor(u.getY() * 100000);
        assertEquals(a, 68965);
        assertEquals(b, 72413);
    }

    @Test
    public void dotTest() {
        assertEquals(u.dot(v), 144);
    }

    @Test
    public void reverseTest() {
        Vector2 w = v.getReverse();
        assertEquals(w.getX(), -3);
        assertEquals(w.getY(), -4);
    }

    @Test
    public void opPE_Test() {
        Vector2 w = v.plusEquals(v);
        assertEquals(w.getX(), 6);
        assertEquals(w.getY(), 8);
    }

    @Test
    public void opME_Test() {
        Vector2 w = v.minusEquals(v);
        assertEquals(w.getX(), 0);
        assertEquals(w.getY(), 0);
    }

    @Test
    public void opTE_Test() {
        Vector2 w = v.timesEquals(3);
        assertEquals(w.getX(), 9);
        assertEquals(w.getY(), 12);
    }

    @Test
    public void opDE_Test() {
        Vector2 w = v.divideEquals(2);
        assertEquals(w.getX(), 1.5);
        assertEquals(w.getY(), 2);
    }



}
