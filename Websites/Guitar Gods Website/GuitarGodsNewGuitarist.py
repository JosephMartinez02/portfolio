import sqlite3


def makeEntry():
    print('---------Insert a New Guitarist---------')
    name = input('Guitarist Name or Ailias: ')
    description = input('Give a Brief Description About this Guitarist: ')
    picture = input(
        'File Path to Picture Here (ex: images/buckethead.jpg): ')
    link = input(
        "Link to Guitarist on Song Suggest Page (ex: songsuggest.html#bheadsuggest): ")
    insertGuitarist(name, description, picture, link)


def insertGuitarist(name, description, picture, link):
    conn = None
    try:
        conn = sqlite3.connect('guitargods.db')
        cur = conn.cursor()
        cur.execute('''INSERT INTO guitarists (name, description, picture, link) VALUES (?,?,?,?)''',
                    (name, description, picture, link))
        conn.commit()
        success = 0
    except sqlite3.Error as err:
        print('Database ERROR', err)
        success = -1
    finally:
        if conn != None:
            conn.close()
    return success


if __name__ == '__main__':
    makeEntry()
