class Response
	
	include System::Collections::Generic
	include Nircbot::Core::Irc::Messages	
	include IResponse # Module

	attr_accessor :message
	attr_accessor :message_type
	attr_accessor :message_format
	attr_accessor :targets

	@message_type = MessageType
	@message_format = MessageFormat
	
	def initialize
		@message = ""
		@message_type = MessageType.Public
		@message_format = MessageFormat.Message
		@targets = System::Collections::Generic::List.of(String).new
	end

end