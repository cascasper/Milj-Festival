CREATE TRIGGER log_msg_board_changes
AFTER INSERT OR UPDATE OR DELETE
ON msg_board
FOR EACH ROW
EXECUTE PROCEDURE log_query();