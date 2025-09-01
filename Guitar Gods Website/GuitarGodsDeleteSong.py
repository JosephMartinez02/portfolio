import sqlite3
import GuitarGodsReadOneSong


def delete():
    artistName = ""
    songName = ""
    songLink = ""
    artistName, songName, songLink = GuitarGodsReadOneSong.getEntry()
    if songName == "ERROR":
        print("Song not found :<")
    else:
        rUSure = input("Are you sure you want to DELETE this song? (y/n): ")
        if rUSure == "y":
            songDeleted = deleteSong(songName)
            print(f'{songDeleted} was deleted from the database. :<')
        else:
            print("Song not deleted. Connection Closed...")


def deleteSong(songName):
    conn = None
    try:
        conn = sqlite3.connect('guitargods.db')
        cur = conn.cursor()
        cur.execute('''DELETE FROM songs WHERE songName == ?''', (songName,))
        conn.commit()
        songDeleted = songName
    except sqlite3.Error as err:
        print('Database ERROR', err)
    finally:
        if conn != None:
            conn.close()
    return songDeleted


if __name__ == '__main__':
    delete()
