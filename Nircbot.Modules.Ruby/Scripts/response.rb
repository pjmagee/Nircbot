class Response
	
	include System::Collections::Generic
	include Nircbot::Core::Irc::Messages	
	include Nircbot::Core::Irc::Messages::IResponse

	attr_accessor :message
	attr_accessor :message_type
	attr_accessor :message_format
	attr_accessor :targets

	@message_type = MessageType
	@message_format = MessageFormat
	@message = ""
	@targets = List.of(String)
	
	def initialize(message, targets, message_format, message_type)
		@message = message
		@message_type = message_type
		@message_format = message_format
	end
	
	
	def initialize
		@message = ""
		@message_type = MessageType.Public
		@message_format = MessageFormat.Message
		@targets = List.of(String).new
	end

end