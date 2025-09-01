import sqlite3


def readAll():
    conn = None
    results = []
    try:
        conn = sqlite3.connect('guitargods.db')
        cur = conn.cursor()
        cur.execute('''SELECT * FROM guitarists ORDER BY name DESC''')
        results = cur.fetchall()
    except sqlite3.Error as err:
        print('Database ERROR', err)
    finally:
        if conn != None:
            conn.close()
    return results


if __name__ == '__main__':
    readAll()
