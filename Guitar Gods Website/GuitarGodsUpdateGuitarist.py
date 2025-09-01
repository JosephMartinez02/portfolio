import sqlite3
import GuitarGodsReadOneGuitarist


def update():
    name = ""
    description = ""
    picture = ""
    link = ""
    name, description, picture, link = GuitarGodsReadOneGuitarist.getEntry()
    if name == "ERROR":
        print("Guitarist not found :<")
    else:
        description = input("New Description: ")
        picture = input("New Picture File Path: ")
        link = input("New HTML Link: ")
        guitaristUpdated = updateGuitarist(name, description, picture, link)


def updateGuitarist(name, description, picture, link):
    conn = None
    try:
        conn = sqlite3.connect('guitargods.db')
        cur = conn.cursor()
        cur.execute('''UPDATE guitarists SET description = ?, picture = ?, link = ? WHERE lower(name) == ?''',
                    (name, description, picture, link))
        conn.commit()
        updated = 1
    except sqlite3.Error as err:
        print('Database ERROR', err)
        updated = 0
    finally:
        if conn != None:
            conn.close()
    return updated


if __name__ == '__main__':
    update()
