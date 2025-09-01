import sqlite3


def makeEntry():
    print('---------Insert a New Song---------')
    artistName = input("Enter Guitarist Name and/or Band: ")
    songName = input("Enter Song Name: ")
    songLink = input("Give the Embed Link to the Song: ")
    insertSong(artistName, songName, songLink)


def insertSong(artistName, songName, songLink):
    conn = None
    try:
        conn = sqlite3.connect('guitargods.db')
        cur = conn.cursor()
        cur.execute('''INSERT INTO songs (artistName, songName, songLink) VALUES (?,?,?)''',
                    (artistName, songName, songLink))
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
