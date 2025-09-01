import sqlite3
import GuitarGodsReadOneGuitarist


def delete():
    name = ""
    description = ""
    picture = ""
    link = ""
    name, description, picture, link = GuitarGodsReadOneGuitarist.getEntry()
    if name == "ERROR":
        print("Guitarist not found :<")
    else:
        rUSure = input(
            "Are you sure you want to DELETE this guitarist? (y/n): ")
        if rUSure == "y":
            personDeleted = deleteGuitarist(name)
            print(f'{personDeleted} was deleted from the database. :<')
        else:
            print("Guitarist not deleted. Connection Closed...")


def deleteGuitarist(name):
    conn = None
    try:
        conn = sqlite3.connect('guitargods.db')
        cur = conn.cursor()
        cur.execute('''DELETE FROM guitarists WHERE name == ?''', (name,))
        conn.commit()
        personDeleted = name
    except sqlite3.Error as err:
        print('Database ERROR', err)
    finally:
        if conn != None:
            conn.close()
    return personDeleted


if __name__ == '__main__':
    delete()
