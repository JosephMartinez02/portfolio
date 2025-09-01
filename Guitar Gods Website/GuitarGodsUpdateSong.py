import sqlite3
import GuitarGodsReadOneSong


def update():
    artistName = ""
    songName = ""
    songLink = ""
    artistName, songName, songLink = GuitarGodsReadOneSong.getEntry()
    if songName == "ERROR":
        print("Song not found :<")
    else:
        songName = input("New Song Name: ")
        songLink = input("New Song Link: ")
        songUpdated = updateSong(artistName, songName, songLink)


def updateSong(artistName, songName, songLink):
    conn = None
    try:
        conn = sqlite3.connect('guitargods.db')
        cur = conn.cursor()
        cur.execute('''UPDATE songs SET songName = ?, songLink = ? WHERE lower(songName) == ?''',
                    (artistName, songName, songLink))
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
