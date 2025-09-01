import sqlite3


def getEntry():
    guitarist = input("Enter Guitarist to Search for: ")
    name, description, picture, link = readGuitarist(guitarist)
    if name == "":
        name = "ERROR"
    else:
        print(
            f'Guitarist: {name:<20} Description: {description:<200} ' f'Picture: {picture:<30} Link: {link:<40}')
    return name, description, picture, link


def readGuitarist(guitarist):
    name = ""
    description = ""
    picture = ""
    link = ""
    conn = None
    results = []
    try:
        conn = sqlite3.connect('guitargods.db')
        cur = conn.cursor()
        cur.execute(
            '''SELECT * FROM guitarists WHERE lower(name) == ?''', (guitarist.lower(),))
        results = cur.fetchall()
        for row in results:
            name = row[1]
            description = row[2]
            picture = row[3]
            link = row[4]
    except sqlite3.Error as err:
        print('Database ERROR', err)
    finally:
        if conn != None:
            conn.close()
    return name, description, picture, link


if __name__ == "__main__":
    getEntry()
